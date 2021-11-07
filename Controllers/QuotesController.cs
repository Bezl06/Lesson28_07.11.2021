using Microsoft.AspNetCore.Mvc;
using Lesson28.Data;
using Microsoft.EntityFrameworkCore;
using Lesson28.Models;

namespace Lesson28.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly QuotesContext _context;
        public QuotesController(QuotesContext context)
        {
            _context = context;
            var arr = _context.Quotes.Where(x => x.InsertDate.AddDays(31) <= DateTime.Today).ToArray();
            if (arr.Length == 0)
                return;
            _context.Quotes.RemoveRange(arr);
        }
        [HttpGet]
        public async Task<ActionResult<List<Quotes>>> Get()
        {
            var quotes = await _context.Quotes.ToListAsync();
            if (quotes.Count == 0)
                return NotFound();
            return quotes;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Quotes>> Get(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
                return NotFound();
            return quote;
        }
        [HttpPost]
        public async Task<ActionResult<Quotes>> Post(Quotes quote)
        {
            if (quote == null || !ModelState.IsValid)
                return BadRequest();
            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = quote.Id }, quote);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Quotes quote)
        {
            if (id != quote.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Entry(quote).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var existQuote = await _context.Quotes.FindAsync(id);
                if (existQuote == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Lesson28.Models;

namespace Lesson28.Data
{
    public class QuotesContext : DbContext
    {
        public QuotesContext(DbContextOptions<QuotesContext> options)
            : base(options)
        {
        }
        public DbSet<Quotes> Quotes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotes>().HasData(
                new Quotes { Id = 1, Text = "Цитата №1", InsertDate = DateTime.Today, Author = "Некий Великий Ноунейм №1" },
                new Quotes { Id = 2, Text = "Цитата №2", InsertDate = DateTime.Today, Author = "Некий Великий Ноунейм №2" },
                new Quotes { Id = 3, Text = "Цитата №3", InsertDate = DateTime.Today, Author = "Некий Великий Ноунейм №3" },
                new Quotes { Id = 4, Text = "Цитата №4", InsertDate = DateTime.Today, Author = "Некий Великий Ноунейм №4" },
                new Quotes { Id = 5, Text = "Цитата №5", InsertDate = DateTime.Today, Author = "Некий Великий Ноунейм №5" }
            );
        }
    }
}
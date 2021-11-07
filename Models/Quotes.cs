using System.ComponentModel.DataAnnotations;

namespace Lesson28.Models
{
    public class Quotes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите текст цитаты...")]
        public string Text { get; set; }
        public string Author { get; set; }
        [Required(ErrorMessage = "Укажите дату..."), DataType(DataType.Date)]
        public DateTime InsertDate { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Book
    {
        [Required]
        public int id {  get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
    }
}

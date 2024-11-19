using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "PublishedDate is required")]
        public DateTime PublishedDate { get; set; }
        public List<Author>? Authors { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}

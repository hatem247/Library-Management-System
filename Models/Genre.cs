using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Genre Name is required")]
        public string Name { get; set; }

        public List<Book>? Books { get; set; }
    }
}

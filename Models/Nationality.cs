using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nationality Name is required")]
        public string Name { get; set; }

        public List<Author>? Authors { get; set; }
    }
}

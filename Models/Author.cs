using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Format")]
        public string Phone { get; set; }
        public List<Book>? Books { get; set; }
        public CreditCard? CreditCard { get; set; }
        public int NationalityId { get; set; }
        public Nationality? Nationality { get; set; }
    }
}

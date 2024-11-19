using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Credit Card Number is required")]
        [Range(100, 999, ErrorMessage = "Invalid Credit Card Number")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Expire Date is required")]
        public DateTime ExpireDate { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}

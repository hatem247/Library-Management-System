using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.CardDtos
{
    public class CreditCardDto
    {
        public int Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public int AuthorId { get; set; }
    }
}
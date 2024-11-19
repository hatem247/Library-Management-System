using FinalWithTheGang.Dtos.BookDtos;
using FinalWithTheGang.Dtos.CardDtos;
using FinalWithTheGang.Dtos.NationalitDtos;
using FinalWithTheGang.Models;
using Library_Management_System.Dtos.GenreDtos;
using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.AuthorDtos
{
    public class AuthorDtoToAddAndGet
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public CreditCardDto? CreditCard { get; set; }
        public int NationalityId { get; set; }
        public List<BookDtoForAuthor>? BookDtoForAuthors { get; set; }
    }
}

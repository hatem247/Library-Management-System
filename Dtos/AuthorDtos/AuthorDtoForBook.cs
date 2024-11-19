using FinalWithTheGang.Dtos.GenreDtos;
using FinalWithTheGang.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.AuthorDtos
{
    public class AuthorDtoForBook
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CreditCardId { get; set; }
        public int NationalityId { get; set; }
    }
}

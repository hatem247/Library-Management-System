using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.AuthorDtos
{
    public class AuthorDtoToGetAuthorOnly
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

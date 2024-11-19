using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.AuthorDtos
{
    public class AuthorDtoToUpdateAuthorOnly
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}

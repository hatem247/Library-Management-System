using FinalWithTheGang.Dtos.AuthorDtos;
using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.NationalitDtos
{
    public class NationalityDtoToGet
    {
        [Required]
        public string Name { get; set; }
        public List<AuthorDtoToGetAuthorOnly> AuthorOnly { get; set; }
    }
}

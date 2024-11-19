using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.NationalitDtos
{
    public class NationalityDtoToAdd
    {
        [Required]
        public string? Name { get; set; }
    }
}

using FinalWithTheGang.Dtos.BookDtos;
using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.GenreDtos
{
    public class GenreDto
    {
        [Required]
        public string? Name { get; set; }
        public List<BookDtoToAddAndGet>? BookDtos { get; set; }
    }
}

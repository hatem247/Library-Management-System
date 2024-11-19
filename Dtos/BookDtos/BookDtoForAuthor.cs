using FinalWithTheGang.Dtos.GenreDtos;
using Library_Management_System.Dtos.GenreDtos;
using System.ComponentModel.DataAnnotations;
namespace FinalWithTheGang.Dtos.BookDtos
{
    public class BookDtoForAuthor
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        public GenreDtoForBook? GenreDto { get; set; }
    }
}

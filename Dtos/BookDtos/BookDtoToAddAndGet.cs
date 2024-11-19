using FinalWithTheGang.Dtos.AuthorDtos;
using System.ComponentModel.DataAnnotations;

namespace FinalWithTheGang.Dtos.BookDtos
{
    public class BookDtoToAddAndGet
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        public int GenreId { get; set; }
        public List<AuthorDtoForBook>? AuthorDtoForBooks { get; set; }
    }
}

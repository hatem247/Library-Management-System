using FinalWithTheGang.Dtos.BookDtos;
using FinalWithTheGang.Dtos.GenreDtos;

namespace Library_Management_System.Repos.Genre_Repos
{
    public interface IGenreRepo
    {
        IEnumerable<GenreDto> GetAll();
        GenreDto GetById(int id);
        void AddGenre(GenreDto genredto);
        void UpdateGenre(GenreDto genredto, int id);
        void DeleteGenre(int id);
        void UpdateGenreOnly(GenreDto genredto, int id);
    }
}

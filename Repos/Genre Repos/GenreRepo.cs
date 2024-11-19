using FinalWithTheGang.Data;
using FinalWithTheGang.Dtos.BookDtos;
using FinalWithTheGang.Dtos.GenreDtos;
using FinalWithTheGang.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repos.Genre_Repos
{
    public class GenreRepo : IGenreRepo
    {
        private readonly DataContext context;
        public GenreRepo(DataContext _context) { context = _context; }
        public void AddGenre(GenreDto genredto)
        {
            Genre genre = new Genre
            {
                Name = genredto.Name,
            };
            context.Genres.Add(genre);
            context.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            Genre genre = context.Genres.FirstOrDefault(x => x.Id == id);
            if (genre != null)
            {
                context.Genres.Remove(genre);
                context.SaveChanges();
            }
        }

        public IEnumerable<GenreDto> GetAll()
        {
            List<GenreDto> genres = context.Genres.Include(g => g.Books).Select(g => new GenreDto
            {
                Name = g.Name,
                BookDtos = g.Books.Select(b => new BookDtoToAddAndGet
                {
                    Title = b.Title,
                    PublishedDate = b.PublishedDate,
                }).ToList()
            }).ToList();
            return genres;
        }

        public GenreDto GetById(int id)
        {
            Genre genre = context.Genres.FirstOrDefault(x => x.Id == id);
            if(genre != null)
            {
                GenreDto genredto = new GenreDto
                {
                    Name = genre.Name,
                    BookDtos = genre.Books.Select(g => new BookDtoToAddAndGet
                    {
                        Title = g.Title,
                        PublishedDate = g.PublishedDate,
                    }).ToList(),
                };
                return genredto;
            }
            return new GenreDto
            {
                Name = "Not Found"
            };
        }

        public void UpdateGenre(GenreDto genredto, int id)
        {
            Genre genre = context.Genres.FirstOrDefault(x => x.Id == id);
            if (genre != null)
            {
                genre.Name = genre.Name;
                genre.Books = genre.Books.Select(g => new Book
                {
                    Title = g.Title,
                    PublishedDate = g.PublishedDate,
                }).ToList();
                context.Genres.Update(genre);
                context.SaveChanges();
            }
        }
        
        public void UpdateGenreOnly(GenreDto genredto, int id)
        {
            Genre genre = context.Genres.FirstOrDefault(x => x.Id == id);
            if (genre != null)
            {
                genre.Name = genre.Name;
                context.Genres.Update(genre);
                context.SaveChanges();
            }
        }
    }
}

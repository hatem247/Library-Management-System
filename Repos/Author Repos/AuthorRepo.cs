using FinalWithTheGang.Data;
using FinalWithTheGang.Dtos.AuthorDtos;
using FinalWithTheGang.Dtos.BookDtos;
using FinalWithTheGang.Dtos.CardDtos;
using FinalWithTheGang.Dtos.GenreDtos;
using FinalWithTheGang.Models;
using Library_Management_System.Dtos.GenreDtos;
using Microsoft.EntityFrameworkCore;

namespace FinalWithTheGang.Repos.AuthorRepos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly DataContext context;
        public AuthorRepo(DataContext _context)
        {
            context = _context;
        }
        public void AddAuthor(AuthorDtoToAddAndGet authorDtoToAdd)
        {
            Author author = new Author
            {
                Email = authorDtoToAdd.EmailAddress,
                Name = authorDtoToAdd.Name,
                Phone = authorDtoToAdd.Phone,
                NationalityId = authorDtoToAdd.NationalityId,
                CreditCard = new CreditCard
                {
                    Number = authorDtoToAdd.CreditCard.Number,
                    ExpireDate = authorDtoToAdd.CreditCard.ExpireDate
                },
                Books = authorDtoToAdd.BookDtoForAuthors.Select(x => new Book
                {
                    PublishedDate = x.PublishedDate,
                    Title = x.Title,
                    Genre = new Genre
                    {
                        Name = x.GenreDto.Name
                    }
                }).ToList(),
            };
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            Author author = context.Authors.FirstOrDefault(x => x.Id == id);
            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }

        public IEnumerable<AuthorDtoToAddAndGet> GetAll()
        {
            List<AuthorDtoToAddAndGet> authors = context.Authors.Include(x => x.CreditCard).Include(x => x.Nationality).Include(x => x.Books).ThenInclude(x => x.Genre).Select(x => new AuthorDtoToAddAndGet
            {
                Name = x.Name,
                Phone = x.Phone,
                CreditCard = new CreditCardDto
                {
                    Number = x.CreditCard.Number,
                    ExpireDate = x.CreditCard.ExpireDate
                },
                EmailAddress = x.Email,
                NationalityId = x.NationalityId,
                BookDtoForAuthors = x.Books.Select(x => new BookDtoForAuthor
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,

                }).ToList()
            }).ToList();
            return authors;
        }

        public AuthorDtoToAddAndGet GetById(int id)
        {
            Author author = context.Authors.FirstOrDefault(x => x.Id == id);
            if(author != null)
            {
                AuthorDtoToAddAndGet Author = new AuthorDtoToAddAndGet
                {
                    Name = author.Name,
                    Phone = author.Phone,
                    CreditCard = new CreditCardDto
                    {
                        Number = author.CreditCard.Number,
                        ExpireDate = author.CreditCard.ExpireDate
                    },
                    EmailAddress = author.Email,
                    NationalityId = author.NationalityId,
                    BookDtoForAuthors = author.Books.Select(a => new BookDtoForAuthor
                    {
                        Title = a.Title,
                        PublishedDate = a.PublishedDate,
                        GenreDto = new GenreDtoForBook
                        {
                            Name = a.Genre.Name
                        }
                    }).ToList(),
                };
                return Author;
            }
            return null;
        }

        public void UpdateAuthor(AuthorDtoToAddAndGet authorDtoToUpdate, int id)
        {
            Author author = context.Authors.FirstOrDefault(x => x.Id == id);
            if(author != null)
            {
                author.Name = authorDtoToUpdate.Name;
                author.Email = authorDtoToUpdate.EmailAddress;
                author.Phone = authorDtoToUpdate.Phone;
                author.Books = authorDtoToUpdate.BookDtoForAuthors.Select(x => new Book
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,

                }).ToList();
                author.NationalityId = authorDtoToUpdate.NationalityId;
                author.CreditCard = new CreditCard
                {
                    Number = author.CreditCard.Number,
                    ExpireDate = author.CreditCard.ExpireDate
                };
                context.Authors.Update(author);
                context.SaveChanges();
            }
        }
        public void UpdateAuthorOnly(AuthorDtoToUpdateAuthorOnly authorDtoToUpdate, int id)
        {
            Author author = context.Authors.Include(x => x.Books).Include(x => x.CreditCard).Include(x => x.Nationality).FirstOrDefault(x => x.Id == id);
            if(author != null)
            {
                author.Email = authorDtoToUpdate.EmailAddress;
                author.Phone = authorDtoToUpdate.Phone;
                author.Name = authorDtoToUpdate.Name;
                context.Authors.Update(author);
                context.SaveChanges();
            }
        }
    }
}

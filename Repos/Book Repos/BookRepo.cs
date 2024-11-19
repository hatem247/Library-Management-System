using FinalWithTheGang.Data;
using FinalWithTheGang.Dtos.AuthorDtos;
using FinalWithTheGang.Dtos.BookDtos;
using FinalWithTheGang.Dtos.CardDtos;
using FinalWithTheGang.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Day_With_Gang.Repos.Book_Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext context;
        public BookRepo(DataContext _context)
        { 
            context = _context;
        }

        public void AddBook(BookDtoToAddAndGet BookDtoToAdd)
        {
            var book = new Book
            {
                Title = BookDtoToAdd.Title,
                PublishedDate = BookDtoToAdd.PublishedDate,
                GenreId = BookDtoToAdd.GenreId,
                Authors = BookDtoToAdd.AuthorDtoForBooks.Select(x => new Author
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    NationalityId = x.NationalityId,
                    CreditCard = context.CreditCards.FirstOrDefault(c => c.Id == x.CreditCardId),
                }).ToList(),
            };
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        public IEnumerable<BookDtoToAddAndGet> GetAll()
        {
            List<BookDtoToAddAndGet> books = context.Books.Include(x => x.Genre).Include(x => x.Authors).Select(x => new BookDtoToAddAndGet
            {
                Title = x.Title,
                PublishedDate = x.PublishedDate,
                GenreId = x.GenreId, 
                AuthorDtoForBooks = x.Authors.Select(a => new AuthorDtoForBook
                {
                    Name= a.Name,
                    Email = a.Email,
                    Phone = a.Phone,
                    CreditCardId = a.CreditCard.Id,
                    NationalityId = a.NationalityId
                }).ToList(),
            }).ToList();
            return books;
        }

        public BookDtoToAddAndGet GetById(int id)
        {
            Book book = context.Books.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                BookDtoToAddAndGet bookdto = new BookDtoToAddAndGet
                {
                    Title = book.Title,
                    PublishedDate = book.PublishedDate,
                    GenreId = book.GenreId,
                    AuthorDtoForBooks = book.Authors.Select(x => new AuthorDtoForBook
                    {
                        Name = x.Name,
                        Email = x.Email,
                        Phone = x.Phone,
                        NationalityId = x.NationalityId,
                        CreditCardId = x.CreditCard.Id,
                    }).ToList()
                };
                return bookdto;
            }
            return null;
        }

        public void UpdateBook(BookDtoToAddAndGet BookDtoToUpdate, int id)
        {
            Book book = context.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                book.Title = BookDtoToUpdate.Title;
                book.PublishedDate = BookDtoToUpdate.PublishedDate;
                book.Authors = BookDtoToUpdate.AuthorDtoForBooks.Select(x => new Author
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    CreditCard = context.CreditCards.FirstOrDefault(c => c.Id == x.CreditCardId),
                    NationalityId = x.NationalityId
                }).ToList();
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        public void UpdateBookOnly(BookDtoToUpdateBookOnly BookDtoToUpdateBookOnly, int id)
        {
            Book book = context.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                book.Title = BookDtoToUpdateBookOnly.Title;
                book.PublishedDate = BookDtoToUpdateBookOnly.PublishedDate;
                context.Books.Update(book);
                context.SaveChanges();
            }
        }
    }
}

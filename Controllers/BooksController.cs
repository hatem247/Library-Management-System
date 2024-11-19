using Final_Day_With_Gang.Repos.Book_Repos;
using FinalWithTheGang.Dtos.BookDtos;
using FinalWithTheGang.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Day_With_Gang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo repo;
        public BooksController(IBookRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var book = repo.GetById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var books = repo.GetAll();
            return Ok(books);
        }
        [HttpPost]
        public IActionResult AddBook(BookDtoToAddAndGet book)
        {
            repo.AddBook(book);
            return Created();
        }
        [HttpPut("{Id} UpdateBookOnly")]
        public IActionResult UpdateBookOnly(BookDtoToUpdateBookOnly book, int Id)
        {
            if(Id == null || Id < 1)
            {
                return NotFound();
            }
            repo.UpdateBookOnly(book, Id);
            return Accepted();
        }
        [HttpPut("{Id} UpdateBook")]
        public IActionResult UpdateBook(BookDtoToAddAndGet book, int Id)
        {
            if(Id == null || Id < 1)
            {
                return NotFound();
            }
            repo.UpdateBook(book, Id);
            return Accepted();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteBook(int Id)
        {
            if (Id == null || Id < 1)
            {
                return NotFound();
            }
            repo.DeleteBook(Id);
            return NoContent();
        }
    }
}

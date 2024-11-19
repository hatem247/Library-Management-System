using Final_Day_With_Gang.Repos.Book_Repos;
using FinalWithTheGang.Dtos.AuthorDtos;
using FinalWithTheGang.Repos.AuthorRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalWithTheGang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo repo;
        public AuthorsController(IAuthorRepo _repo)
        {
            repo = _repo;
        }
        [HttpPost]
        public IActionResult AddAuthor(AuthorDtoToAddAndGet authorDtoToAddAndGet)
        {
            repo.AddAuthor(authorDtoToAddAndGet);
            return Created();
        }
        [HttpGet]
        public IActionResult GetAuthor() {
            var a = repo.GetAll();
            return Ok(a);
        }
        [HttpGet("{Id}")]
        public IActionResult GetSingleAuthor(int Id)
        {
            var a = repo.GetById(Id);
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut("AllAuthorData {Id}")]
        public IActionResult UpdateAuthor(AuthorDtoToAddAndGet authorDtoToAddAndGet, int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            repo.UpdateAuthor(authorDtoToAddAndGet, Id);
            return Accepted();
        }
        [HttpPut("AuthorDataOnly {Id}")]
        public IActionResult UpdateAuthorOnly(AuthorDtoToUpdateAuthorOnly authorDtoToUpdate, int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }
            repo.UpdateAuthorOnly(authorDtoToUpdate, Id);
            return Accepted();
        }
    }
}

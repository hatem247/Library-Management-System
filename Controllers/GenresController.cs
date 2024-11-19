using FinalWithTheGang.Dtos.GenreDtos;
using Library_Management_System.Repos.Genre_Repos;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepo repo;

        public GenresController(IGenreRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet("{Id}")]
        public IActionResult GetGenre(int Id)
        {
            GenreDto genre = repo.GetById(Id);
            if(genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllGenres()
        {
            IEnumerable<GenreDto> genres = repo.GetAll();
            if(genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }
        [HttpPost]
        public IActionResult AddGenre(GenreDto genre)
        {
            repo.AddGenre(genre);
            return Created();
        }
        [HttpPut("{Id} UpdateGenre")]
        public IActionResult UpdateGenre(GenreDto genre, int Id)
        {
            repo.UpdateGenre(genre, Id);
            if(Id == null || Id < 1)
            {
                return NotFound();
            }
            return Accepted();
        }
        [HttpPut("{Id} UpdateGenreOnly")]
        public IActionResult UpdateGenreOnly(GenreDto genre, int Id)
        {
            if(Id == null || Id < 1)
            {
                return NotFound();
            }
            repo.UpdateGenreOnly(genre, Id);
            return Accepted();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteGenre(int Id)
        {
            if (Id == null || Id < 1)
            {
                return NotFound();
            }
            repo.DeleteGenre(Id);
            return NoContent();
        }
    }
}

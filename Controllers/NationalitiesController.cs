using Final_Day_With_Gang.Repos.Nationality_Repos;
using FinalWithTheGang.Dtos.NationalitDtos;
using FinalWithTheGang.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Day_With_Gang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly INationalityRepo repo;
        public NationalitiesController(INationalityRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet("{Id}")]
        public IActionResult GetNationality(int Id)
        {
            NationalityDtoToGet nationality = repo.GetById(Id);
            if(nationality == null)
            {
                return NotFound();
            }
            return Ok(nationality);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllNationalities()
        {
            IEnumerable<NationalityDtoToGet> nationalities = repo.GetAll();
            return Ok(nationalities);
        }

        [HttpPost]
        public IActionResult AddNationality(NationalityDtoToAdd nationality)
        {
            repo.Add(nationality);
            return Created();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateNationality(NationalityDtoToAdd nationality, int Id)
        {
            if(Id == null ||  Id < 1)
            {
                return NotFound();
            }
            repo.Update(nationality, Id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult DeleteNationality(int Id)
        {
            if (Id == null || Id < 1)
            {
                return NotFound();
            }
            repo.Delete(Id);
            return NoContent();
        }
    }
}

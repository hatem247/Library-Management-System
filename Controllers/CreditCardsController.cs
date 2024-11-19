using FinalWithTheGang.Dtos.CardDtos;
using Library_Management_System.Repos.CreditCard_Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardRepo repo;
        public CreditCardsController(ICreditCardRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet("{Id} GetCreditCard")]
        public IActionResult GetCreditCard(int Id)
        {
            CreditCardDto card = repo.GetById(Id);
            if(card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }
        [HttpGet("GetAllCreditCards")]
        public IActionResult GetAllCreditCards()
        {
            IEnumerable<CreditCardDto> cards = repo.GetAll();
            if(cards == null)
            {
                return NotFound();
            }
            return Ok(cards);
        }
        [HttpPost]
        public IActionResult AddCreditCard(CreditCardDto card)
        {
            repo.AddCard(card);
            return Created();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateCreditCard(CreditCardDto card, int Id)
        {
            repo.UpdateCard(card, Id);
            return Accepted();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteCreditCard(int Id)
        {
            repo.DeleteCard(Id);
            return NoContent();
        }
    }
}

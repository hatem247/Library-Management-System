using FinalWithTheGang.Data;
using FinalWithTheGang.Dtos.CardDtos;
using FinalWithTheGang.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repos.CreditCard_Repos
{
    public class CreditCardRepo : ICreditCardRepo
    {
        private readonly DataContext context;
        public CreditCardRepo(DataContext _context) { context = _context; }

        public void AddCard(CreditCardDto cardDto)
        {
            CreditCard card = new CreditCard()
            {
                Number = cardDto.Number,
                ExpireDate = cardDto.ExpireDate
            };
            context.CreditCards.Add(card);
            context.SaveChanges();
        }

        public void DeleteCard(int Id)
        {
            CreditCard card = context.CreditCards.FirstOrDefault(c => c.Id == Id);
            if (card != null)
            {
                context.CreditCards.Remove(card);
                context.SaveChanges();
            }
        }

        public IEnumerable<CreditCardDto> GetAll()
        {
            List<CreditCardDto> credits = context.CreditCards.Include(c => c.Author).Select(c => new CreditCardDto
            {
                Number = c.Number,
                ExpireDate = c.ExpireDate,
            }).ToList();
            return credits;
        }

        public CreditCardDto GetById(int Id)
        {
            CreditCard credit = context.CreditCards.Include(c => c.Author).FirstOrDefault(x => x.Id == Id);
            if (credit != null)
            {
                CreditCardDto carddto = new CreditCardDto
                {
                    Number = credit.Number,
                    ExpireDate = credit.ExpireDate,
                };
                return carddto;
            }
            return null;
        }

        public void UpdateCard(CreditCardDto cardDto, int Id)
        {
            CreditCard credit = context.CreditCards.FirstOrDefault(c => c.Id == Id);
            if (credit != null)
            {
                credit.Number = cardDto.Number;
                credit.ExpireDate = cardDto.ExpireDate;
                context.CreditCards.Update(credit);
                context.SaveChanges();
            }
        }
    }
}

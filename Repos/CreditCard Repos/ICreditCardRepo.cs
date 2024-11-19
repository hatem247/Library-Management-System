using FinalWithTheGang.Dtos.CardDtos;
using FinalWithTheGang.Dtos.CardDtos;

namespace Library_Management_System.Repos.CreditCard_Repos
{
    public interface ICreditCardRepo
    {
        IEnumerable<CreditCardDto> GetAll();
        CreditCardDto GetById(int Id);
        void AddCard(CreditCardDto cardDto);
        void UpdateCard(CreditCardDto cardDto, int Id);
        void DeleteCard(int id);
    }
}

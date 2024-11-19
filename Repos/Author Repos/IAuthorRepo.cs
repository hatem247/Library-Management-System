using FinalWithTheGang.Dtos.AuthorDtos;

namespace FinalWithTheGang.Repos.AuthorRepos
{
    public interface IAuthorRepo
    {
        IEnumerable<AuthorDtoToAddAndGet> GetAll();
        AuthorDtoToAddAndGet GetById(int id);
        void AddAuthor(AuthorDtoToAddAndGet authorDtoToAdd);
        void UpdateAuthor(AuthorDtoToAddAndGet authorDtoToAdd , int id);
        void DeleteAuthor(int id);
        void UpdateAuthorOnly(AuthorDtoToUpdateAuthorOnly authorDtoToUpdate , int id);
    }
}

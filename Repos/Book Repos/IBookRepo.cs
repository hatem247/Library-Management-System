using FinalWithTheGang.Dtos.BookDtos;

namespace Final_Day_With_Gang.Repos.Book_Repos
{
    public interface IBookRepo
    {
        IEnumerable<BookDtoToAddAndGet> GetAll();
        BookDtoToAddAndGet GetById(int id);
        void AddBook(BookDtoToAddAndGet BookDtoToAdd);
        void UpdateBook(BookDtoToAddAndGet BookDtoToUpdate, int id);
        void DeleteBook(int id);
        void UpdateBookOnly(BookDtoToUpdateBookOnly BookDtoToUpdateBookOnly, int id);
    }
}

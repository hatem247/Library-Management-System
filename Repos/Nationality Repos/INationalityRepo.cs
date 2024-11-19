using FinalWithTheGang.Dtos.NationalitDtos;

namespace Final_Day_With_Gang.Repos.Nationality_Repos
{
    public interface INationalityRepo
    {
        NationalityDtoToGet GetById(int Id);
        IEnumerable<NationalityDtoToGet> GetAll();
        void Add(NationalityDtoToAdd narionalitydto);
        void Update(NationalityDtoToAdd narionalitydto, int Id);
        void Delete(int Id);
    }
}

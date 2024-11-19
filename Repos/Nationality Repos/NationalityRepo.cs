using FinalWithTheGang.Data;
using FinalWithTheGang.Dtos.AuthorDtos;
using FinalWithTheGang.Dtos.NationalitDtos;
using FinalWithTheGang.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Day_With_Gang.Repos.Nationality_Repos
{
    public class NationalityRepo : INationalityRepo
    {
        private readonly DataContext context;
        public NationalityRepo(DataContext _context)
        {
            context = _context;
        }
        public void Add(NationalityDtoToAdd narionalitydto)
        {
            Nationality nationality = new Nationality
            {
                Name = narionalitydto.Name
            };
            context.Nationalities.Add(nationality);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Nationality nationality = context.Nationalities.FirstOrDefault(n => n.Id == Id);
            if (nationality != null)
            {
                context.Nationalities.Remove(nationality);
                context.SaveChanges();
            }
        }

        public IEnumerable<NationalityDtoToGet> GetAll()
        {
            List<NationalityDtoToGet> nationalities = context.Nationalities.Include(n => n.Authors).Select(n => new NationalityDtoToGet
            {
                Name = n.Name,
                AuthorOnly = n.Authors.Select(a => new AuthorDtoToGetAuthorOnly
                {
                    Email = a.Email,
                    Name = a.Name,
                    Phone = a.Phone
                }).ToList(),
            }).ToList();
            return nationalities;
        }

        public NationalityDtoToGet GetById(int Id)
        {
            Nationality nationality = context.Nationalities.FirstOrDefault(n => n.Id == Id);
            if(nationality != null)
            {
                NationalityDtoToGet nationalityDto = new NationalityDtoToGet
                {
                    Name = nationality.Name,
                };
                return nationalityDto;
            }
            return null;
        }

        public void Update(NationalityDtoToAdd narionalitydto, int Id)
        {
            Nationality nationality = context.Nationalities.FirstOrDefault(n => n.Id == Id);
            if(nationality != null)
            {
                nationality.Name = narionalitydto.Name;
                context.Nationalities.Update(nationality);
                context.SaveChanges();
            }
        }
    }
}

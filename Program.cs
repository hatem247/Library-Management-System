
using Final_Day_With_Gang.Repos.Book_Repos;
using Final_Day_With_Gang.Repos.Nationality_Repos;
using FinalWithTheGang.Data;
using FinalWithTheGang.Repos.AuthorRepos;
using Library_Management_System.Repos.CreditCard_Repos;
using Library_Management_System.Repos.Genre_Repos;
using Microsoft.EntityFrameworkCore;

namespace FinalWithTheGang
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
            builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<ICreditCardRepo, CreditCardRepo>();
            builder.Services.AddScoped<IGenreRepo, GenreRepo>();
            builder.Services.AddScoped<INationalityRepo, NationalityRepo>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

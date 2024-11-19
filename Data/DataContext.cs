using FinalWithTheGang.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalWithTheGang.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(x => x.Authors).WithMany(v => v.Books);
            modelBuilder.Entity<CreditCard>().HasOne(x => x.Author).WithOne(v => v.CreditCard);
        }
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set;}
        public DbSet<Genre> Genres { get; set;}
        public DbSet<CreditCard> CreditCards { get; set;}
        public DbSet<Nationality> Nationalities { get; set;}
    }
}

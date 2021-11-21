using Microsoft.EntityFrameworkCore;

namespace LabaOPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<Person>? Users { get; set; }
        public DbSet<PersonBook>? BorrowedBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}

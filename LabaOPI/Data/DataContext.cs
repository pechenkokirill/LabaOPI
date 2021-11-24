using Microsoft.EntityFrameworkCore;

namespace LabaOPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Person>? Users { get; set; }
        public DbSet<PersonBook>? BorrowedBooks { get; set; }
    }
}

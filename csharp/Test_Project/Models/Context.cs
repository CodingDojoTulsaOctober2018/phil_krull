using Microsoft.EntityFrameworkCore;
 
namespace Test_Project.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Author> Authors {get;set;}
        public DbSet<Book> Books {get;set;}
        public DbSet<Publisher> Publishers {get; set;}
        public DbSet<PublishedBy> PublishedBook {get; set;}
    }
}

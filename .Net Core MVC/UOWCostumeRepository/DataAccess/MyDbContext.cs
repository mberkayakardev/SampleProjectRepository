using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> optionsBuilder) : base (optionsBuilder)
        {
            
        }

        public DbSet<People> peoples { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}

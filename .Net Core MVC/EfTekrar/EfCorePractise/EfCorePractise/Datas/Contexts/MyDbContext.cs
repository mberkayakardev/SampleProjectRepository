using EfCorePractise.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractise.Datas.Contexts
{
    internal class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.185;Database=lastefpractise;User Id=locallogin;password=Qwerasdf0147;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Iphone 14", Price = 65000, Description = "New Iphone " },
                new Product { Id = 2, Name = "Galaxy s22", Price = 45000, Description = "New Galaxy series " },
                new Product { Id = 3, Name = "Samsung Watch4", Price = 5000, Description = "Latest Smartwatch" }
                );
        }


        #region DbSets

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Kategoriler { get; set; }


        #endregion
    }
}

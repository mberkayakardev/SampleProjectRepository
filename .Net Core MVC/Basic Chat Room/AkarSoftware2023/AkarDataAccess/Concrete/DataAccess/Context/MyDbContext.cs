using AkarDataAccess.Concrete.DataAccess.Configuration;
using AkarEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AkarDataAccess.Concrete.DataAccess.Context
{
    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder) // ModelBuilder üzerinden konfigürasyon yapmak için kullanılmaktadır. 
        {
            modelBuilder.ApplyConfiguration(new UserModelConfiguration());
            modelBuilder.ApplyConfiguration(new GroupModelConfiguration());
            modelBuilder.ApplyConfiguration(new TokenModelConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SKDUDAU; Database=myDataBase;User Id=BERKAYAKAR;Password=Qwerasdf0147;");
        }


        #region DbSet
        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Token> Tokens { get; set; }
        #endregion

    }
}

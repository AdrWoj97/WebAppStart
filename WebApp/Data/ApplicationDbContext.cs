using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Kategorie> Kategorie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategorie>().HasData(
                new Kategorie { KategorieId = 1, Name = "Akcja", DisplayOrder = 1 },
                new Kategorie { KategorieId = 2, Name = "SciFi", DisplayOrder = 2 },
                new Kategorie { KategorieId = 3, Name = "Historia", DisplayOrder = 3 }
                );
        }
    }
}

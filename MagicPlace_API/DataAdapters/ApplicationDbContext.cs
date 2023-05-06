using MagicPlace_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicPlace_API.DataAdapters
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    Id = 1,
                    Name = "Test",
                    Detail = "test",
                    ImageUrl = "test",
                    Ocupants = 5,
                    SquareMeters = 5,
                    Cost = 5,
                    Service = "",
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now

                });
        }
    }
}

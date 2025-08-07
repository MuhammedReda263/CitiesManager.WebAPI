using CitiesManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.WebAPI.DatabaseContext
{
    public class ApllicationDbContext : DbContext
    {
        public ApllicationDbContext(DbContextOptions options) : base(options) { }
        public ApllicationDbContext () {}

        public virtual DbSet <City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(new City() { Id = Guid.Parse("20BC80C4-A6D3-4DD0-BAE7-51109D3F045F"), Name = "London" },
                new City() { Id = Guid.Parse("0D59132A-BF7A-489B-9071-56DC0511759C"), Name = "Cairo" });
        }
    }
}

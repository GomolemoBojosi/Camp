using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Campground> Campgrounds { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .ToTable("SouthAfricanCities", "dbo");

            modelBuilder.Entity<Campground>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Campground)
                .HasForeignKey(r => r.CampgroundId);

           
            modelBuilder.Entity<City>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}

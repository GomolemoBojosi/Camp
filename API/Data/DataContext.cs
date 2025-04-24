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
            .WithOne()
            .HasForeignKey(r => r.CampgroundId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
            .HasOne<Campground>()
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CampgroundId)
            .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<City>().Metadata.SetIsTableExcludedFromMigrations(true);
        }
    }
}

using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seeder
    {
        public static async Task SeedData(DataContext context)
        {
            // ensuring the database is not already seeded
            if (context.Campgrounds.Any()) return;

            var random = new Random();

            //fetch cities from the database
            var cities = await context.Cities.ToListAsync();

            var descriptors = new[] { "Forest", "Ancient", "Petrified", "Roaring" }; // Example descriptors
            var places = new[] { "Flats", "Village", "Canyon", "Pond" }; // Example places

            for( var i = 0; i < 50; i++ )
            {
                var randomCity = cities[random.Next(cities.Count)];
                var campground = new Campground
                {
                    Location = $"{randomCity.CityName}, {randomCity.ProvinceName}",
                    Title = $"{descriptors[random.Next(descriptors.Length)]}"
                };
                context.Campgrounds.Add( campground );
            }

            await context.SaveChangesAsync();

        }
    }
}

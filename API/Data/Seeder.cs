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

            var descriptors = new[] { "Forest", "Ancient", "Petrified", "Roaring" }; 
            var places = new[] { "Flats", "Village", "Canyon", "Pond" }; 

            for( var i = 0; i < 50; i++ )
            {
                var randomCity = cities[random.Next(cities.Count)];
                var price = random.Next(10, 30).ToString();
                var randomImageNumber = random.Next(1, 1000);

                var campground = new Campground
                {
                    Location = $"{randomCity.CityName}, {randomCity.ProvinceName}",
                    Title = $"{descriptors[random.Next(descriptors.Length)]} {places[random.Next(places.Length)]}",
                    Image = $"https://picsum.photos/400?random={randomImageNumber}",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,",
                    Price = price
                };

                context.Campgrounds.Add(campground);
            }

            await context.SaveChangesAsync();

        }
    }
}

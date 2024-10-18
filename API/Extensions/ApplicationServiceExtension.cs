using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this WebApplicationBuilder builder, IConfigurationBuilder config) {
            builder.Services.AddScoped<ICampgroundRepository, CampgroundRepository>();
            builder.Services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder.Services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Commons.Interfaces;
using Travel.Data.Contexts;

namespace Travel.Data
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services, IConfiguration config)
        {
   

            services.AddDbContext<TravelDbContext>(options => options
                .UseSqlite(config.GetConnectionString("DefaultConnection"))); // db connection string changed to config redis

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<TravelDbContext>());

            return services;
        }
        
    }
}
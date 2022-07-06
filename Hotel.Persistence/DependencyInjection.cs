using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Interfaces;

namespace Hotel.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<HotelDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IHotelDbContext>(provider => provider.GetService<HotelDbContext>());
            return services;
        }
    }
}

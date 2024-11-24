using App.Core.Interfaces;
using App.Core.Options;
using App.Infrastructure.Data;
using App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public static class DependencyInjection
    {

        // without options pattern
        //public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<AppDbContext>(options =>
        //    {
        //        //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        //    });

        //    services.AddScoped<IUserRepository, UserRepository>();
        //    return services;
        //}


        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCoreModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection string okuma
            var connectionString = configuration.GetConnectionString("Default");

            // AppDbContext ekleme
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}

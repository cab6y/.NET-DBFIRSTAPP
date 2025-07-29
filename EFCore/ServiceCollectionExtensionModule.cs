using Domain.Entities.TodoItem;
using EFCore.TodoItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore
{
    public static class ServiceCollectionExtensionModule
    {
        public static IServiceCollection AddEfCoreModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITodoItemRepository, EFCoreTodoItemRepository>();

            // Connection string okuma
            var connectionString = configuration.GetConnectionString("Default");

            // AppDbContext ekleme
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}

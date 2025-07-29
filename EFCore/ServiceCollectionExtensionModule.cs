using Domain.Entities.TodoItem;
using EFCore.DBContext;
using EFCore.Interceptors;
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
            services.AddScoped<SoftDeleteInterceptor>();

            services.AddScoped<ITodoItemRepository, EFCoreTodoItemRepository>();

            // Connection string okuma
            var connectionString = configuration.GetConnectionString("Default");

            // AppDbContext ekleme
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // --- Stored Procedure kontrolü ---
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                StoredProcedureInitializer.EnsureStoredProceduresCreatedAsync(dbContext).GetAwaiter().GetResult();
            }
            return services;
        }
    }
}

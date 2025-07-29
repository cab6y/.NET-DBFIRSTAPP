using Application.TodoItems;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ContractsModule
    {
        public static IServiceCollection AddContractsModule(this IServiceCollection services)
        {
            // Application implementasyonlarını buradan kaydet
            services.AddScoped<ITodoItemAppService, TodoItemAppService>();

            // İleride yeni servis eklediğinde buraya ekleyebilirsin
            return services;
        }
    }
}

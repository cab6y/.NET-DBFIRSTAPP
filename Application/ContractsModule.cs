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

            // AutoMapper profillerini ekle
            services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

            return services;
        }


    }
}

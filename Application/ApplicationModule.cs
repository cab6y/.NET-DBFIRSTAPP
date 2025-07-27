using Application.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            // Tüm servisleri burada ekle
            services.AddScoped<ITestAppService, TestAppService>();

            // İleride başka servisler de buraya eklenir
            return services;
        }
    }
}

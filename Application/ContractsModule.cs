using Application.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ContractsModule
    {
        public static IServiceCollection AddContractsModule(this IServiceCollection services)
        {
            // Application implementasyonlarını buradan kaydet
            services.AddScoped<ITestAppService, TestAppService>();

            // İleride yeni servis eklediğinde buraya ekleyebilirsin
            return services;
        }
    }
}

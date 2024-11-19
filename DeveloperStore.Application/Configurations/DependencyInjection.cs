using DeveloperStore.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DeveloperStore.Application.VendaServices;

namespace DeveloperStore.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registro do serviço de vendas
            services.AddScoped<IVendaService, VendaService>();

            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using TaxStrategy.Application.Interface;
using TaxStrategy.Application.Services;
using TaxStrategy.Domain.Interfaces;
using TaxStrategy.Infra.Data.Repositories;

namespace TaxStrategy.Infrastructure.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ITaxStrategyPaiService, TaxStrategyPaiService>();
            services.AddScoped<ITaxStrategyFilhoService, TaxStrategyFilhoService>();

            // Domain e Infra.Data
            services.AddScoped<ITaxStrategyPaiRepository, TaxStrategyPaiRepository>();
            services.AddScoped<ITaxStrategyFilhoRepository, TaxStrategyFilhoRepository>();
        }
    }
}

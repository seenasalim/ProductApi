using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Contracts.Infrastructure;
using Product.Application.Contracts.Persistence;
using Product.Application.Models;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;

namespace Product.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {   
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICatalogContext, ProductContext>();

            return services;
        }
    }
}

using ECommerce.Data;
using ECommerce.Data.Repository;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ApiDbContext>();

            return services;
        }
    }
}

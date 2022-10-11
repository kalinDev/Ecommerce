using ECommerce.Application.Interfaces;
using ECommerce.Application.Notifications;
using ECommerce.Application.Services;
using ECommerce.Data;
using ECommerce.Data.Repository;
using ECommerce.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infra.CrossCutting.Ioc.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ApiDbContext>();
        }
    }
}

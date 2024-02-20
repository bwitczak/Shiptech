using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application;

namespace Shiptech.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddApplication();

            return services;
        }
    }
}
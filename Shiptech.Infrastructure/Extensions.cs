using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application;
using Shiptech.Shared;

namespace Shiptech.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Queries
            services.AddQueriesAbstraction();

            // --> Read
            // TODO: Queries register

            return services;
        }
    }
}
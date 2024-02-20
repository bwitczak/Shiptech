using Microsoft.Extensions.DependencyInjection;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;
using Shiptech.Shared.Commands;
using Shiptech.Shared.Queries;

namespace Shiptech.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommandsAbstraction(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

            return services;
        }
        
        public static IServiceCollection AddQueriesAbstraction(this IServiceCollection services)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Commands;

namespace Shiptech.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddCommandsAbstraction(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

            return services;
        }
    }
}
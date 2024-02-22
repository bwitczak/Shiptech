using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.Queries.Handlers;
using Shiptech.Shared;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Queries
            services.AddQueriesAbstraction();

            // --> Read
            services.AddScoped<IQueryHandler<GetAllShips, IEnumerable<ShipDto>>, GetAllShipsHandler>();
            services.AddScoped<IQueryHandler<GetPagedDrawings, IEnumerable<DrawingDto>>, GetPagedDrawingsHandler>();
            services.AddScoped<IQueryHandler<GetShip, ShipDto>, GetShipHandler>();

            return services;
        }
    }
}
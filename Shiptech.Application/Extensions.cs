using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application.Commands;
using Shiptech.Application.Commands.Handlers;
using Shiptech.Domain.Factories;
using Shiptech.Shared;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Commands
            services.AddCommandsAbstraction();
            services.AddScoped<ICommandHandler<CreateShip>, CreateShipHandler>();
            services.AddScoped<ICommandHandler<CreateDrawing>, CreateDrawingHandler>();
            services.AddScoped<ICommandHandler<CreateIso>, CreateIsoHandler>();
            services.AddScoped<ICommandHandler<CreateAssortment>, CreateAssortmentHandler>();
            services.AddScoped<ICommandHandler<CreateChemicalProcess>, CreateChemicalProcessHandler>();

            // Factories
            services.AddScoped<IShipFactory, ShipFactory>();
            services.AddScoped<IDrawingFactory, DrawingFactory>();
            services.AddScoped<IIsoFactory, IsoFactory>();
            services.AddScoped<IAssortmentFactory, AssortmentFactory>();
            services.AddScoped<IChemicalProcessFactory, ChemicalProcessFactory>();

            // Policies

            return services;
        }
    }
}
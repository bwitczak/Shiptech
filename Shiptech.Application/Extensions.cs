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

            //  --> Create
            services.AddScoped<ICommandHandler<CreateShip>, CreateShipHandler>();
            services.AddScoped<ICommandHandler<CreateDrawing>, CreateDrawingHandler>();
            services.AddScoped<ICommandHandler<CreateIso>, CreateIsoHandler>();
            services.AddScoped<ICommandHandler<CreateAssortment>, CreateAssortmentHandler>();
            services.AddScoped<ICommandHandler<CreateChemicalProcess>, CreateChemicalProcessHandler>();

            //  --> Update
            services.AddScoped<ICommandHandler<UpdateShip>, UpdateShipHandler>();
            services.AddScoped<ICommandHandler<UpdateDrawing>, UpdateDrawingHandler>();
            services.AddScoped<ICommandHandler<UpdateIso>, UpdateIsoHandler>();
            services.AddScoped<ICommandHandler<UpdateAssortment>, UpdateAssortmentHandler>();
            services.AddScoped<ICommandHandler<UpdateChemicalProcess>, UpdateChemicalProcessHandler>();

            //  --> Delete
            services.AddScoped<ICommandHandler<DeleteShip>, DeleteShipHandler>();
            services.AddScoped<ICommandHandler<DeleteDrawing>, DeleteDrawingHandler>();
            services.AddScoped<ICommandHandler<DeleteIso>, DeleteIsoHandler>();
            services.AddScoped<ICommandHandler<DeleteAssortment>, DeleteAssortmentHandler>();
            services.AddScoped<ICommandHandler<DeleteChemicalProcess>, DeleteChemicalProcessHandler>();

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
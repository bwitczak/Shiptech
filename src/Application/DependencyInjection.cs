using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application.Common.Behaviours;
using Shiptech.Domain.Factories;

namespace Shiptech.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
        });

        // Factories
        services.AddScoped<IShipownerFactory, ShipownerFactory>();
        services.AddScoped<IShipFactory, ShipFactory>();
        services.AddScoped<IDrawingFactory, DrawingFactory>();
        services.AddScoped<IIsoFactory, IsoFactory>();
        services.AddScoped<IAssortmentFactory, AssortmentFactory>();
        services.AddScoped<IAssortmentDictionaryFactory, AssortmentDictionaryFactory>();
        services.AddScoped<IChemicalProcessFactory, ChemicalProcessFactory>();

        return services;
    }
}

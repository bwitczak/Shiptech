using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Infrastructure.Data;
using Shiptech.Infrastructure.Data.Interceptors;
using Shiptech.Infrastructure.Data.Services;

namespace Shiptech.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddSingleton(TimeProvider.System);

        // Services
        services.AddScoped<IShipownerService, ShipownerService>();
        services.AddScoped<IShipService, ShipService>();
        services.AddScoped<IDrawingService, DrawingService>();
        services.AddScoped<IIsoService, IsoService>();
        services.AddScoped<IAssortmentService, AssortmentService>();
        services.AddScoped<IAssortmentDictionaryService, AssortmentDictionaryService>();
        services.AddScoped<IChemicalProcessService, ChemicalProcessService>();

        return services;
    }
}

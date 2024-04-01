using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shiptech.Application;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Domain.Repositories;
using Shiptech.Infrastructure.AutoMapper;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Options;
using Shiptech.Infrastructure.EF.Repositories;
using Shiptech.Infrastructure.EF.Services;
using Shiptech.Infrastructure.Queries.Handlers;
using Shiptech.Shared;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Database
            var databaseOptions = configuration.GetOptions<DatabaseOptions>("Database");
            services.AddDbContext<ReadDbContext>(context => { context.UseNpgsql(databaseOptions.ConnectionString); });
            services.AddDbContext<WriteDbContext>(context => { context.UseNpgsql(databaseOptions.ConnectionString); });
            
            // AutoMapper
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());   
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Repositories
            services.AddScoped<IShipRepository, ShipRepository>();
            services.AddScoped<IDrawingRepository, DrawingRepository>();
            services.AddScoped<IIsoRepository, IsoRepository>();
            services.AddScoped<IAssortmentRepository, AssortmentRepository>();
            services.AddScoped<IChemicalProcessRepository, ChemicalProcessRepository>();

            // Services
            services.AddScoped<IShipReadService, ShipService>();
            services.AddScoped<IDrawingReadService, DrawingService>();
            services.AddScoped<IIsoReadService, IsoService>();
            services.AddScoped<IAssortmentReadService, AssortmentService>();
            services.AddScoped<IChemicalProcessReadService, ChemicalProcessService>();
            services.AddScoped<IAssortmentDictionaryReadService, AssortmentDictionaryService>();

            // Queries
            services.AddQueriesAbstraction();

            // --> Read
            services.AddScoped<IQueryHandler<GetAllShips, IEnumerable<ShipWithNoRelationsDto>>, GetAllShipsHandler>();
            services.AddScoped<IQueryHandler<GetPagedDrawings, IEnumerable<DrawingWithNoRelationsDto>>, GetPagedDrawingsHandler>();
            services.AddScoped<IQueryHandler<GetShip, ShipDto>, GetShipHandler>();
            services.AddScoped<IQueryHandler<GetPagedAssortmentDictionary, IEnumerable<AssortmentDictionaryWithNoRelationsDto>>, GetPagedAssortmentDictionaryHandler>();

            return services;
        }

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ReadDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<ReadDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
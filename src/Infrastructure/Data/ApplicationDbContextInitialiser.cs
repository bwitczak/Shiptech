using System.Reflection;
using Faker;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using IServiceScope? scope = app.Services.CreateScope();

        ApplicationDbContextInitialiser? initialiser =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        if (await initialiser.HasPendingMigrationsAsync())
        {
            await initialiser.InitialiseAsync();
            await initialiser.SeedAsync();
        }
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<bool> HasPendingMigrationsAsync()
    {
        try
        {
            IEnumerable<string> pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

            return pendingMigrations.Any();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while checking for pending migrations.");
            throw;
        }
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        await ExecuteSqlScript();
        await SeedFakeData();
    }

    private async Task ExecuteSqlScript()
    {
        try
        {
            string? basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (basePath != null)
            {
                string scriptPath = Path.Combine(basePath, "Data", "Scripts", "AssortmentDictionary.sql");

                if (File.Exists(scriptPath))
                {
                    string sql = await File.ReadAllTextAsync(scriptPath);
                    await _context.Database.ExecuteSqlRawAsync(sql);
                    _logger.LogInformation("Executed SQL seed script successfully");
                }
                else
                {
                    _logger.LogWarning("SQL seed script not found at {Path}", scriptPath);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while executing SQL seed script");
            throw;
        }
    }

    private async Task SeedFakeData()
    {
        IEnumerable<Shipowner> shipOwners = new ShipownerFaker().Generate(5).DistinctBy(x => x.Orderer).ToList();
        await _context.Shipowners.AddRangeAsync(shipOwners);

        List<Ship>? ships = new ShipFaker(shipOwners).Generate(5);
        await _context.Ships.AddRangeAsync(ships);

        List<Drawing>? drawings = new DrawingFaker(ships).Generate(100);
        await _context.Drawings.AddRangeAsync(drawings);

        List<ChemicalProcess> chemicalProcesses =
            new ChemicalProcessFaker().Generate(5).DistinctBy(x => x.Name).ToList();
        await _context.ChemicalProcesses.AddRangeAsync(chemicalProcesses);

        List<Iso>? isos = new IsoFaker(drawings, chemicalProcesses).Generate(10000);
        await _context.Isos.AddRangeAsync(isos);

        List<AssortmentDictionary> assortmentDictionaries = await _context.AssortmentDictionaries.ToListAsync();
        List<Assortment>? assortments = new AssortmentFaker(isos, assortmentDictionaries).Generate(50000);
        await _context.Assortments.AddRangeAsync(assortments);

        await _context.SaveChangesAsync();
    }
}

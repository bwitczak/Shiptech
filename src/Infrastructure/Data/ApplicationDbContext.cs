using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Ship> Ships => Set<Ship>();
    public DbSet<Drawing> Drawings => Set<Drawing>();
    public DbSet<Iso> Isos => Set<Iso>();
    public DbSet<Assortment> Assortments => Set<Assortment>();
    public DbSet<ChemicalProcess> ChemicalProcesses => Set<ChemicalProcess>();
    public DbSet<AssortmentDictionary> AssortmentDictionaries => Set<AssortmentDictionary>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.EF.Configurations;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Ship> Ship { get; set; }
    public DbSet<Drawing> Drawing { get; set; }
    public DbSet<Iso> Iso { get; set; }
    public DbSet<Assortment> Assortment { get; set; }
    public DbSet<ChemicalProcess> ChemicalProcess { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Ship>(configuration);
        modelBuilder.ApplyConfiguration<Drawing>(configuration);
        modelBuilder.ApplyConfiguration<Iso>(configuration);
        modelBuilder.ApplyConfiguration<Assortment>(configuration);
        modelBuilder.ApplyConfiguration<ChemicalProcess>(configuration);
    }
}

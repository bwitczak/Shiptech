using Microsoft.EntityFrameworkCore;
using Shiptech.Infrastructure.EF.Configurations;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<ShipReadModel> Ship { get; set; }
    public DbSet<DrawingReadModel> Drawing { get; set; }
    public DbSet<IsoReadModel> Iso { get; set; }
    public DbSet<AssortmentReadModel> Assortment { get; set; }
    public DbSet<ChemicalProcessReadModel> ChemicalProcess { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<ShipReadModel>(configuration);
        modelBuilder.ApplyConfiguration<DrawingReadModel>(configuration);
        modelBuilder.ApplyConfiguration<IsoReadModel>(configuration);
        modelBuilder.ApplyConfiguration<AssortmentReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ChemicalProcessReadModel>(configuration);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Configurations;

internal class ReadConfiguration : IEntityTypeConfiguration<ShipReadModel>, IEntityTypeConfiguration<DrawingReadModel>,
    IEntityTypeConfiguration<IsoReadModel>, IEntityTypeConfiguration<AssortmentReadModel>,
    IEntityTypeConfiguration<ChemicalProcessReadModel>
{
    public void Configure(EntityTypeBuilder<ShipReadModel> builder)
    {
        // builder.Property(x => x.Id)
        //     .HasColumnName("Id");
        //
        // builder.Property(x => x.Orderer)
        //     .HasColumnName("Orderer");

        builder.ToTable("Ships");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Drawings)
            .WithOne(x => x.Ship);
    }

    public void Configure(EntityTypeBuilder<DrawingReadModel> builder)
    {
        builder.ToTable("Drawings");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Isos)
            .WithOne(x => x.Drawing);
    }

    public void Configure(EntityTypeBuilder<IsoReadModel> builder)
    {
        builder.ToTable("Isos");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Assortments)
            .WithOne(x => x.Iso);
    }

    public void Configure(EntityTypeBuilder<AssortmentReadModel> builder)
    {
        builder.ToTable("Assortments");
        builder.HasKey(x => x.Id);
    }

    public void Configure(EntityTypeBuilder<ChemicalProcessReadModel> builder)
    {
        builder.ToTable("ChemicalProcesses");
        builder.HasKey(x => x.Id);
    }
}
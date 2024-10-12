using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class ShipownerConfiguration : IEntityTypeConfiguration<Shipowner>
{
    public void Configure(EntityTypeBuilder<Shipowner> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("varchar(26)")
            .HasConversion<UlidToStringConverter>()
            .IsRequired();

        builder.Property(x => x.Orderer)
            .HasColumnName("Orderer")
            .HasColumnType("varchar")
            .IsRequired();

        builder.HasMany(x => x.Ships)
            .WithOne(x => x.Shipowner);
    }
}

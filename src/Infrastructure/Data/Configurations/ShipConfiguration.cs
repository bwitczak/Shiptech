using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class ShipConfiguration : IEntityTypeConfiguration<Ship>
{
    public void Configure(EntityTypeBuilder<Ship> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("varchar(26)")
            .HasConversion<UlidToStringConverter>()
            .IsRequired();
        
        builder.Property(x => x.Code)
            .HasColumnName("Code")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.Orderer)
            .HasColumnName("Orderer")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Ships");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Drawings)
            .WithOne(x => x.Ship);
    }
}

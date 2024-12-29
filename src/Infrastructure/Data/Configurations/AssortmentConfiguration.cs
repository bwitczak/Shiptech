using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class AssortmentConfiguration : IEntityTypeConfiguration<Assortment>
{
    public void Configure(EntityTypeBuilder<Assortment> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("varchar(26)")
            .HasConversion<UlidToStringConverter>()
            .IsRequired();

        builder.Property(x => x.Position)
            .HasColumnName("Position")
            .HasColumnType("varchar(1)")
            .IsRequired();

        builder.Property(x => x.PrefabricationQuantity)
            .HasColumnName("PrefabricationQuantity")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.PrefabricationLength)
            .HasColumnName("PrefabricationLength")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.PrefabricationWeight)
            .HasColumnName("PrefabricationWeight")
            .HasColumnType("decimal(8,3)")
            .IsRequired();

        builder.Property(x => x.AssemblyQuantity)
            .HasColumnName("AssemblyQuantity")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.AssemblyLength)
            .HasColumnName("AssemblyLength")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(x => x.AssemblyWeight)
            .HasColumnName("AssemblyWeight")
            .HasColumnType("decimal(8,3)")
            .IsRequired();

        builder.Property(x => x.PG)
            .HasColumnName("PG")
            .HasColumnType("varchar(1)")
            .IsRequired();

        builder.Property(x => x.ValveNumber)
            .HasColumnName("ValveNumber")
            .HasColumnType("varchar");

        builder.Property(x => x.CutAngle)
            .HasColumnName("CutAngle")
            .HasColumnType("varchar");

        builder.Property(x => x.Comment)
            .HasColumnName("Comment")
            .HasColumnType("varchar");

        builder.Property(x => x.Created)
            .HasColumnName("CreationDate")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("Author")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Assortments");
        builder.HasKey(x => x.Id);
    }
}

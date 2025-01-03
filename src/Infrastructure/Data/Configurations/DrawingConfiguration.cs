using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class DrawingConfiguration : IEntityTypeConfiguration<Drawing>
{
    public void Configure(EntityTypeBuilder<Drawing> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("varchar(26)")
            .HasConversion<UlidToStringConverter>()
            .IsRequired();

        builder.Property(x => x.Number)
            .HasColumnName("Number")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Revision)
            .HasColumnName("Revision")
            .HasColumnType("varchar(2)")
            .IsRequired();

        builder.Property(x => x.Lot)
            .HasColumnName("Lot")
            .HasColumnType("varchar(3)");

        builder.Property(x => x.Block)
            .HasColumnName("Block")
            .HasColumnType("varchar(3)");

        builder.Property(x => x.Section)
            .HasColumnName("Section")
            .HasColumnType("text[]");

        builder.Property(x => x.Stage)
            .HasColumnName("Stage")
            .HasColumnType("varchar(3)");

        builder.Property(x => x.Created)
            .HasColumnName("CreationDate")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("Author")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Drawings");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Number).IsUnique();
        builder.HasMany(x => x.Isos)
            .WithOne(x => x.Drawing);
    }
}

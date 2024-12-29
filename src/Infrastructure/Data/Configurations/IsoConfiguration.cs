using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class IsoConfiguration : IEntityTypeConfiguration<Iso>
{
    public void Configure(EntityTypeBuilder<Iso> builder)
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

        builder.Property(x => x.Nameplate)
            .HasColumnName("Nameplate")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Revision)
            .HasColumnName("Revision")
            .HasColumnType("varchar(2)")
            .IsRequired();

        builder.Property(x => x.System)
            .HasColumnName("System")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Class)
            .HasColumnName("Class")
            .HasColumnType("varchar(6)")
            .IsRequired();

        builder.Property(x => x.Atest)
            .HasColumnName("Atest")
            .HasColumnType("varchar");

        builder.Property(x => x.KzmNumber)
            .HasColumnName("KzmNumber")
            .HasColumnType("varchar(6)");

        builder.Property(x => x.KzmDate)
            .HasColumnName("KzmDate")
            .HasColumnType("date");

        builder.Property(x => x.Created)
            .HasColumnName("CreationDate")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("Author")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Isos");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Assortments)
            .WithOne(x => x.Iso);
    }
}

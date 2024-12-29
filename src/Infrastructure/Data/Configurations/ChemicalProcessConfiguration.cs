using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class ChemicalProcessConfiguration : IEntityTypeConfiguration<ChemicalProcess>
{
    public void Configure(EntityTypeBuilder<ChemicalProcess> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("varchar(26)")
            .HasConversion<UlidToStringConverter>()
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("ChemicalProcessCode")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("ChemicalProcessName")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("ChemicalProcesses");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Isos)
            .WithOne(x => x.ChemicalProcess);
    }
}

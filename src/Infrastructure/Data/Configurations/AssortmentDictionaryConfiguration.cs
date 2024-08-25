using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Domain.Entities;
using Shiptech.Infrastructure.Data.Converters;

namespace Shiptech.Infrastructure.Data.Configurations;

public class AssortmentDictionaryConfiguration : IEntityTypeConfiguration<AssortmentDictionary>
{
    public void Configure(EntityTypeBuilder<AssortmentDictionary> builder)
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
        
        builder.Property(x => x.Distinguishing)
            .HasColumnName("Distinguishing")
            .HasColumnType("char(22)")
            .IsRequired();
        
        builder.Property(x => x.Unit)
            .HasColumnName("Unit")
            .HasColumnType("char(4)")
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasColumnName("Amount")
            .HasColumnType("decimal(5,3)");

        builder.Property(x => x.Weight)
            .HasColumnName("Weight")
            .HasColumnType("decimal(5,3)");

        builder.Property(x => x.Material)
            .HasColumnName("Material")
            .HasColumnType("varchar");
        
        builder.Property(x => x.Kind)
            .HasColumnName("Kind")
            .HasColumnType("varchar");
        
        builder.Property(x => x.DN1)
            .HasColumnName("DN1")
            .HasColumnType("varchar");
        
        builder.Property(x => x.DN2)
            .HasColumnName("DN2")
            .HasColumnType("varchar");
        
        builder.Property(x => x.Length)
            .HasColumnName("Length")
            .HasColumnType("smallint");
        
        builder.Property(x => x.RO)
            .HasColumnName("RO")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasColumnName("Comment")
            .HasColumnType("varchar");
        
        builder.ToTable("AssortmentDictionary");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Assortments)
            .WithOne(x => x.AssortmentDictionary);
    }
}

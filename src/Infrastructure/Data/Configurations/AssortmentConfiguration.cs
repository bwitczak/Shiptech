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
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.Position)
            .HasColumnName("Position")
            .HasColumnType("char(1)")
            .IsRequired();
        
        builder.Property(x => x.DrawingLength)
            .HasColumnName("DrawingLength")
            .HasColumnType("smallint");
        
        builder.Property(x => x.Addition)
            .HasColumnName("Addition")
            .HasColumnType("smallint");
        
        builder.Property(x => x.TechnologicalAddition)
            .HasColumnName("TechnologicalAddition")
            .HasColumnType("smallint");
        
        builder.Property(x => x.Stage)
            .HasColumnName("Stage")
            .HasColumnType("char(1)");
        
        builder.Property(x => x.Comment)
            .HasColumnName("Comment")
            .HasColumnType("varchar");
        
        builder.Property(x => x.D15I)
            .HasColumnName("D15I")
            .HasColumnType("smallint");
        
        builder.Property(x => x.D15II)
            .HasColumnName("D15II")
            .HasColumnType("smallint");
        
        builder.Property(x => x.D1I)
            .HasColumnName("D1I")
            .HasColumnType("smallint");
        
        builder.Property(x => x.D1II)
            .HasColumnName("D1II")
            .HasColumnType("smallint");
        
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
            .HasColumnType("decimal(5,3)")
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
            .HasColumnType("decimal(5,3)")
            .IsRequired();
        
        builder.ToTable("Assortments");
        builder.HasKey(x => x.Id);
    }
}

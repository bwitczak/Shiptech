using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Configurations;

internal class ReadConfiguration : IEntityTypeConfiguration<ShipReadModel>, IEntityTypeConfiguration<DrawingReadModel>,
    IEntityTypeConfiguration<IsoReadModel>, IEntityTypeConfiguration<AssortmentReadModel>,
    IEntityTypeConfiguration<ChemicalProcessReadModel>, IEntityTypeConfiguration<AssortmentDictionaryReadModel>
{
    public void Configure(EntityTypeBuilder<ShipReadModel> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        
        builder.Property(x => x.Orderer)
            .HasColumnName("Orderer")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Ships");
        builder.HasKey(x => x.Orderer);
        builder.HasMany(x => x.Drawings)
            .WithOne(x => x.Ship);
    }

    public void Configure(EntityTypeBuilder<DrawingReadModel> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.DrawingRevision)
            .HasColumnName("DrawingRevision")
            .HasColumnType("char(1)")
            .IsRequired();
        
        builder.Property(x => x.Lot)
            .HasColumnName("Lot")
            .HasColumnType("char(3)");
        
        builder.Property(x => x.Block)
            .HasColumnName("Block")
            .HasColumnType("char(3)");
        
        builder.Property(x => x.Section)
            .HasColumnName("Section")
            .HasColumnType("text[]");
        
        builder.Property(x => x.Stage)
            .HasColumnName("Stage")
            .HasColumnType("char(3)");
        
        builder.Property(x => x.CreationDate)
            .HasColumnName("CreationDate")
            .HasColumnType("timestamp")
            .IsRequired();
        
        builder.Property(x => x.Author)
            .HasColumnName("Author")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.ToTable("Drawings");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Isos)
            .WithOne(x => x.Drawing);
    }

    public void Configure(EntityTypeBuilder<IsoReadModel> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.IsoRevision)
            .HasColumnName("DrawingRevision")
            .HasColumnType("char(1)")
            .IsRequired();
        
        builder.Property(x => x.System)
            .HasColumnName("System")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.Class)
            .HasColumnName("Class")
            .HasColumnType("char(6)")
            .IsRequired();
        
        builder.Property(x => x.Atest)
            .HasColumnName("Atest")
            .HasColumnType("varchar");
        
        builder.Property(x => x.KzmNumber)
            .HasColumnName("KzmNumber")
            .HasColumnType("char(6)");
        
        builder.Property(x => x.KzmDate)
            .HasColumnName("KzmDate")
            .HasColumnType("timestamp");
        
        builder.ToTable("Isos");
        builder.HasKey(x => x.Name);
        builder.HasMany(x => x.Assortments)
            .WithOne(x => x.Iso);
    }

    public void Configure(EntityTypeBuilder<AssortmentReadModel> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
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
        builder.HasKey(x => x.Name);
    }

    public void Configure(EntityTypeBuilder<ChemicalProcessReadModel> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        
        builder.Property(x => x.ChemicalProcessCode)
            .HasColumnName("ChemicalProcessCode")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.ChemicalProcessName)
            .HasColumnName("ChemicalProcessName")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.ToTable("ChemicalProcesses");
        builder.HasKey(x => x.ChemicalProcessCode);
        builder.HasMany(x => x.Isos)
            .WithOne(x => x.ChemicalProcess);
    }

    public void Configure(EntityTypeBuilder<AssortmentDictionaryReadModel> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(x => x.Distinguishing)
            .HasColumnName("Distinguishing")
            .HasColumnType("char(6)")
            .IsRequired();
        
        builder.Property(x => x.Unit)
            .HasColumnName("Unit")
            .HasColumnType("char(4)")
            .IsRequired();
        
        builder.Property(x => x.Amount)
            .HasColumnName("Amount")
            .HasColumnType("decimal(5,3)")
            .IsRequired();
        
        builder.Property(x => x.Weight)
            .HasColumnName("Weight")
            .HasColumnType("decimal(5,3)")
            .IsRequired();

        builder.Property(x => x.Material)
            .HasColumnName("Material")
            .HasColumnType("varchar");
        
        builder.Property(x => x.Kind)
            .HasColumnName("Kind")
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
        builder.HasKey(x => x.Name);
        builder.HasMany(x => x.Assortments)
            .WithOne(x => x.AssortmentDictionary);
    }
}
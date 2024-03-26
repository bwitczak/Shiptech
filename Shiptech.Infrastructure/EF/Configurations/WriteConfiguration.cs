using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shiptech.Domain.Consts;
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Models.Consts;

namespace Shiptech.Infrastructure.EF.Configurations;

internal class WriteConfiguration : IEntityTypeConfiguration<Ship>, IEntityTypeConfiguration<Drawing>,
    IEntityTypeConfiguration<Iso>, IEntityTypeConfiguration<Assortment>, IEntityTypeConfiguration<ChemicalProcess>,
    IEntityTypeConfiguration<AssortmentDictionary>
{
    public void Configure(EntityTypeBuilder<Ship> builder)
    {
        var ordererConverter = new ValueConverter<Orderer, string>(x => x.Value, x => new Orderer(x));

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new ShipId(x));

        builder.Property(typeof(Orderer), "_orderer")
            .HasConversion(ordererConverter)
            .HasColumnName("Orderer")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Ships");
        builder.HasKey(x => x.Id);
        builder.HasIndex("_orderer").IsUnique();
        builder.HasMany(typeof(Drawing), "_drawings");
    }

    public void Configure(EntityTypeBuilder<Drawing> builder)
    {
        var drawingRevisionConverter = new ValueConverter<Revision, char>(x => x.Value, x => new Revision(x));
        var lotConverter = new ValueConverter<Lot, string?>(x => x.Value, x => new Lot(x));
        var blockConverter = new ValueConverter<Block, string?>(x => x.Value, x => new Block(x));
        var sectionConverter = new ValueConverter<Section, string?>(x => x.Value, x => new Section(x));
        var stageConverter = new ValueConverter<Stage, string?>(
            x => x.Value,
            x => ConvertStage(x));
        var dateConverter = new ValueConverter<CreationDate, DateTime>(x => (DateTime) x.Value!, x => new CreationDate(x));
        var authorConverter = new ValueConverter<Author, string>(x => x.Value, x => new Author(x));

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new DrawingId(x));

        builder.Property(typeof(Revision), "_drawingRevision")
            .HasConversion(drawingRevisionConverter)
            .HasColumnName("DrawingRevision")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(typeof(Lot), "_lot")
            .HasConversion(lotConverter)
            .HasColumnName("Lot")
            .HasColumnType("char(3)");

        builder.Property(typeof(Block), "_block")
            .HasConversion(blockConverter)
            .HasColumnName("Block")
            .HasColumnType("char(3)");

        builder.Property(typeof(Section), "_section")
            .HasConversion(sectionConverter)
            .HasColumnName("Section")
            .HasColumnType("char(4)");

        builder.Property(typeof(Stage), "_stage")
            .HasConversion(stageConverter)
            .HasColumnName("Stage")
            .HasColumnType("char(3)");

        builder.Property(typeof(CreationDate), "_creationDate")
            .HasConversion(dateConverter)
            .HasColumnName("CreationDate")
            .HasColumnType("timestamp")
            .IsRequired();

        builder.Property(typeof(Author), "_author")
            .HasConversion(authorConverter)
            .HasColumnName("Author")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("Drawings");
        builder.HasKey(x => x.Id);
        builder.HasMany(typeof(Iso), "_isos");
    }

    public void Configure(EntityTypeBuilder<Iso> builder)
    {
        var isoRevisionConverter = new ValueConverter<Revision, char>(x => x.Value, x => new Revision(x));
        var isoSystemConverter = new ValueConverter<IsoSystem, string>(x => x.Value, x => new IsoSystem(x));
        var classConverter = new ValueConverter<Class, string>(x => x.Value, x => new Class(x));
        var atestConverter =
            new ValueConverter<Atest, string?>(x => x.Value,
                x => ConvertAtest(x));
        var kzmNumberConverter = new ValueConverter<KzmNumber, string?>(x => x.Value, x => new KzmNumber(x));
        var kzmDateConverter = new ValueConverter<KzmDate, DateTime?>(x => x.Value, x => new KzmDate(x));

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new IsoId(x));

        builder.Property(typeof(Revision), "_isoRevision")
            .HasConversion(isoRevisionConverter)
            .HasColumnName("DrawingRevision")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(typeof(IsoSystem), "_system")
            .HasConversion(isoSystemConverter)
            .HasColumnName("System")
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(typeof(Class), "_class")
            .HasConversion(classConverter)
            .HasColumnName("Class")
            .HasColumnType("char(6)")
            .IsRequired();

        builder.Property(typeof(Atest), "_atest")
            .HasConversion(atestConverter)
            .HasColumnName("Atest")
            .HasColumnType("varchar");

        builder.Property(typeof(KzmNumber), "_kzmNumber")
            .HasConversion(kzmNumberConverter)
            .HasColumnName("KzmNumber")
            .HasColumnType("char(6)");

        builder.Property(typeof(KzmDate), "_kzmDate")
            .HasConversion(kzmDateConverter)
            .HasColumnName("KzmDate")
            .HasColumnType("timestamp");

        builder.ToTable("Isos");
        builder.HasKey(x => x.Id);
        builder.HasOne(typeof(ChemicalProcess), "_chemicalProcess");
        builder.HasMany(typeof(Assortment), "_assortments");
    }

    public void Configure(EntityTypeBuilder<Assortment> builder)
    {
        var positionConverter = new ValueConverter<Position, char>(x => x.Value, x => new Position(x));
        var drawingLengthConverter =
            new ValueConverter<DrawingLength, ushort?>(x => x.Value, x => new DrawingLength(x));
        var additionConverter =
            new ValueConverter<Addition, ushort?>(x => x.Value, x => new Addition(x));
        var technologicalAdditionConverter =
            new ValueConverter<TechnologicalAddition, ushort?>(x => x.Value,
                x => new TechnologicalAddition(x));
        var assortmentStageConverter =
            new ValueConverter<AssortmentStage, char?>(x => x.Value, x => new AssortmentStage(x));
        var commentConverter =
            new ValueConverter<Comment, string?>(x => x.Value,
                x => new Comment(x));
        var d15IConverter =
            new ValueConverter<D15I, ushort?>(x => x.Value,
                x => new D15I(x));
        var d15IIConverter =
            new ValueConverter<D15II, ushort?>(x => x.Value,
                x => new D15II(x));
        var d1IConverter =
            new ValueConverter<D1I, ushort?>(x => x.Value,
                x => new D1I(x));
        var d1IIConverter =
            new ValueConverter<D1II, ushort?>(x => x.Value,
                x => new D1II(x));
        var prefabricationQuantityConverter =
            new ValueConverter<PrefabricationQuantity, ushort>(x => x.Value,
                x => new PrefabricationQuantity(x));
        var prefabricationLengthConverter =
            new ValueConverter<PrefabricationLength, ushort>(x => x.Value,
                x => new PrefabricationLength(x));
        var prefabricationWeightConverter =
            new ValueConverter<PrefabricationWeight, double>(x => x.Value,
                x => new PrefabricationWeight(x));
        var assemblyQuantityConverter =
            new ValueConverter<AssemblyQuantity, ushort>(x => x.Value,
                x => new AssemblyQuantity(x));
        var assemblyLengthConverter =
            new ValueConverter<AssemblyLength, ushort>(x => x.Value,
                x => new AssemblyLength(x));
        var assemblyWeightConverter =
            new ValueConverter<AssemblyWeight, double>(x => x.Value,
                x => new AssemblyWeight(x));

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AssortmentId(x));

        builder.Property(typeof(Position), "_position")
            .HasConversion(positionConverter)
            .HasColumnName("Position")
            .HasColumnType("char(1)")
            .IsRequired();

        builder.Property(typeof(DrawingLength), "_drawingLength")
            .HasConversion(drawingLengthConverter)
            .HasColumnName("DrawingLength")
            .HasColumnType("smallint");

        builder.Property(typeof(Addition), "_addition")
            .HasConversion(additionConverter)
            .HasColumnName("Addition")
            .HasColumnType("smallint");

        builder.Property(typeof(TechnologicalAddition), "_technologicalAddition")
            .HasConversion(technologicalAdditionConverter)
            .HasColumnName("TechnologicalAddition")
            .HasColumnType("smallint");

        builder.Property(typeof(AssortmentStage), "_stage")
            .HasConversion(assortmentStageConverter)
            .HasColumnName("Stage")
            .HasColumnType("char(1)");
        
        builder.Property(typeof(Comment), "_comment")
            .HasConversion(commentConverter)
            .HasColumnName("Comment")
            .HasColumnType("varchar");

        builder.Property(typeof(D15I), "_d15I")
            .HasConversion(d15IConverter)
            .HasColumnName("D15I")
            .HasColumnType("smallint");

        builder.Property(typeof(D15II), "_d15II")
            .HasConversion(d15IIConverter)
            .HasColumnName("D15II")
            .HasColumnType("smallint");

        builder.Property(typeof(D1I), "_d1I")
            .HasConversion(d1IConverter)
            .HasColumnName("D1I")
            .HasColumnType("smallint");

        builder.Property(typeof(D1II), "_d1II")
            .HasConversion(d1IIConverter)
            .HasColumnName("D1II")
            .HasColumnType("smallint");

        builder.Property(typeof(PrefabricationQuantity), "_prefabricationQuantity")
            .HasConversion(prefabricationQuantityConverter)
            .HasColumnName("PrefabricationQuantity")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(typeof(PrefabricationLength), "_prefabricationLength")
            .HasConversion(prefabricationLengthConverter)
            .HasColumnName("PrefabricationLength")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(typeof(PrefabricationWeight), "_prefabricationWeight")
            .HasConversion(prefabricationWeightConverter)
            .HasColumnName("PrefabricationWeight")
            .HasColumnType("decimal(5,3)")
            .IsRequired();

        builder.Property(typeof(AssemblyQuantity), "_assemblyQuantity")
            .HasConversion(assemblyQuantityConverter)
            .HasColumnName("AssemblyQuantity")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(typeof(AssemblyLength), "_assemblyLength")
            .HasConversion(assemblyLengthConverter)
            .HasColumnName("AssemblyLength")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(typeof(AssemblyWeight), "_assemblyWeight")
            .HasConversion(assemblyWeightConverter)
            .HasColumnName("AssemblyWeight")
            .HasColumnType("decimal(5,3)")
            .IsRequired();

        builder.ToTable("Assortments");
        builder.HasKey(x => x.Id);
        builder.HasOne(typeof(AssortmentDictionary), "_standardNumber");
    }

    public void Configure(EntityTypeBuilder<ChemicalProcess> builder)
    {
        var chemicalProcessNameConverter =
            new ValueConverter<ChemicalProcessName, string>(x => x.Value, x => new ChemicalProcessName(x));

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new ChemicalProcessId(x));

        builder.Property(typeof(ChemicalProcessName), "_chemicalProcessName")
            .HasConversion(chemicalProcessNameConverter)
            .HasColumnName("ChemicalProcessName")
            .HasColumnType("varchar")
            .IsRequired();

        builder.ToTable("ChemicalProcesses");
        builder.HasKey(x => x.Id);
    }
    
    public void Configure(EntityTypeBuilder<AssortmentDictionary> builder)
    {
        var nameConverter = new ValueConverter<AssortmentDictionaryName, string>(x => x.Value, x => new AssortmentDictionaryName(x));
        var distinguishingConverter = new ValueConverter<Distinguishing, string>(x => x.Value, x => new Distinguishing(x));
        var unitConverter = new ValueConverter<Unit, string>(
            x => x.Value,
            x => ConvertUnit(x));
        var amountConverter = new ValueConverter<AssortmentDictionaryAmount, double>(x => x.Value, x => new AssortmentDictionaryAmount(x));
        var weightConverter = new ValueConverter<AssortmentDictionaryWeight, double>(x => x.Value, x => new AssortmentDictionaryWeight(x));
        var materialConverter = new ValueConverter<AssortmentDictionaryMaterial, string?>(x => x.Value, x => new AssortmentDictionaryMaterial(x));
        var kindConverter = new ValueConverter<AssortmentDictionaryKind, string?>(x => x.Value, x => new AssortmentDictionaryKind(x));
        var lengthConverter = new ValueConverter<AssortmentDictionaryLength, ushort>(x => x.Value, x => new AssortmentDictionaryLength(x));
        var roConverter = new ValueConverter<RO, string>(x => x.Value, x => new RO(x));
        var commentConverter = new ValueConverter<Comment, string?>(x => x.Value, x => new Comment(x));
        
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AssortmentDictionaryId(x));

        builder.Property(typeof(AssortmentDictionaryName), "_name")
            .HasConversion(nameConverter)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(typeof(Distinguishing), "_distinguishing")
            .HasConversion(distinguishingConverter)
            .HasColumnName("Distinguishing")
            .HasColumnType("char(6)")
            .IsRequired();
        
        builder.Property(typeof(Unit), "_unit")
            .HasConversion(unitConverter)
            .HasColumnName("Unit")
            .HasColumnType("char(4)")
            .IsRequired();
        
        builder.Property(typeof(AssortmentDictionaryAmount), "_amount")
            .HasConversion(amountConverter)
            .HasColumnName("Amount")
            .HasColumnType("decimal(5,3)")
            .IsRequired();
        
        builder.Property(typeof(AssortmentDictionaryWeight), "_weight")
            .HasConversion(weightConverter)
            .HasColumnName("Weight")
            .HasColumnType("decimal(5,3)")
            .IsRequired();
        
        builder.Property(typeof(AssortmentDictionaryMaterial), "_material")
            .HasConversion(materialConverter)
            .HasColumnName("Material")
            .HasColumnType("varchar");
        
        builder.Property(typeof(AssortmentDictionaryKind), "_kind")
            .HasConversion(kindConverter)
            .HasColumnName("Kind")
            .HasColumnType("varchar");
        
        builder.Property(typeof(AssortmentDictionaryLength), "_length")
            .HasConversion(lengthConverter)
            .HasColumnName("Length")
            .HasColumnType("smallint");
        
        builder.Property(typeof(RO), "_ro")
            .HasConversion(roConverter)
            .HasColumnName("RO")
            .HasColumnType("varchar")
            .IsRequired();
        
        builder.Property(typeof(Comment), "_comment")
            .HasConversion(commentConverter)
            .HasColumnName("Comment")
            .HasColumnType("varchar");
    }
    
    private static string? ConvertAtest(string? x)
    {
        return x switch
        {
            AtestConsts.Yes => AtestConsts.Yes,
            AtestConsts.No => AtestConsts.No,
            _ => StageConsts.None
        };
    }
    
    private static string? ConvertStage(string? x)
    {
        return x switch
        {
            StageConsts.Odi => StageConsts.Odi,
            StageConsts.Odp => StageConsts.Odi,
            StageConsts.Ods => StageConsts.Ods,
            _ => StageConsts.None
        };
    }
    
    private static string ConvertUnit(string x)
    {
        return x switch
        {
            UnitConsts.Kg => UnitConsts.Kg,
            UnitConsts.Szt => UnitConsts.Szt,
            _ => ""
        };
    }
}
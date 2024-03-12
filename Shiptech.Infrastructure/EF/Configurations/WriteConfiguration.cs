using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shiptech.Domain.Consts;
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Infrastructure.EF.Configurations;

internal class WriteConfiguration : IEntityTypeConfiguration<Ship>, IEntityTypeConfiguration<Drawing>,
    IEntityTypeConfiguration<Iso>, IEntityTypeConfiguration<Assortment>, IEntityTypeConfiguration<ChemicalProcess>
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
        builder.HasMany(typeof(Drawing), "_drawings");
    }

    public void Configure(EntityTypeBuilder<Drawing> builder)
    {
        var drawingRevisionConverter = new ValueConverter<Revision, char>(x => x.Value, x => new Revision(x));
        var lotConverter = new ValueConverter<Lot, string>(x => x.Value, x => new Lot(x));
        var blockConverter = new ValueConverter<Block, string>(x => x.Value, x => new Block(x));
        var sectionConverter = new ValueConverter<Section, string>(x => x.Value, x => new Section(x));
        var stageConverter =
            new ValueConverter<Stage, string>(x => x.Value.ToString(),
                x => (StageEnum)Enum.Parse(typeof(StageEnum), x));
        var dateConverter = new ValueConverter<Date, DateTime>(x => (DateTime) x.Value!, x => new Date(x));
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

        builder.Property(typeof(Date), "_date")
            .HasConversion(dateConverter)
            .HasColumnName("Date")
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
            new ValueConverter<Atest, string>(x => x.Value.ToString(),
                x => (Atest)Enum.Parse(typeof(Atest), x));
        var kzmNumberConverter = new ValueConverter<KzmNumber, string>(x => x.Value, x => new KzmNumber(x));
        var kzmDateConverter = new ValueConverter<Date, DateTime?>(x => x.Value, x => new Date(x));

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new IsoId(x));

        builder.Property(typeof(Revision), "_drawingRevision")
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

        builder.Property(typeof(Date), "_kzmDate")
            .HasConversion(kzmDateConverter)
            .HasColumnName("KzmDate")
            .HasColumnType("timestamp");

        // TODO: Add chemical process (required)

        builder.ToTable("Isos");
        builder.HasKey(x => x.Id);
        builder.HasMany(typeof(Assortment), "_assortments");
    }

    public void Configure(EntityTypeBuilder<Assortment> builder)
    {
        var positionConverter = new ValueConverter<Position, char>(x => x.Value, x => new Position(x));
        var drawingLengthConverter =
            new ValueConverter<DrawingLength, short?>(x => x.Value, x => new DrawingLength(x));
        var additionConverter =
            new ValueConverter<Addition, short?>(x => x.Value, x => new Addition(x));
        var technologicalAdditionConverter =
            new ValueConverter<TechnologicalAddition, short?>(x => x.Value,
                x => new TechnologicalAddition(x));
        var assortmentStageConverter =
            new ValueConverter<AssortmentStage, char?>(x => x.Value, x => new AssortmentStage(x));
        var d15IConverter =
            new ValueConverter<D15I, short?>(x => x.Value,
                x => new D15I(x));
        var d15IIConverter =
            new ValueConverter<D15II, short?>(x => x.Value,
                x => new D15II(x));
        var d1IConverter =
            new ValueConverter<D1I, short?>(x => x.Value,
                x => new D1I(x));
        var d1IIConverter =
            new ValueConverter<D1II, short?>(x => x.Value,
                x => new D1II(x));
        var prefabricationQuantityConverter =
            new ValueConverter<PrefabricationQuantity, short>(x => x.Value,
                x => new PrefabricationQuantity(x));
        var prefabricationLengthConverter =
            new ValueConverter<PrefabricationLength, short>(x => x.Value,
                x => new PrefabricationLength(x));
        var prefabricationWeightConverter =
            new ValueConverter<PrefabricationWeight, double>(x => x.Value,
                x => new PrefabricationWeight(x));
        var assemblyQuantityConverter =
            new ValueConverter<AssemblyQuantity, short>(x => x.Value,
                x => new AssemblyQuantity(x));
        var assemblyLengthConverter =
            new ValueConverter<AssemblyLength, short>(x => x.Value,
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
}
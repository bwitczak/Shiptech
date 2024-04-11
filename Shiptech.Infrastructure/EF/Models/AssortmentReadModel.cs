namespace Shiptech.Infrastructure.EF.Models;

internal class AssortmentReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public char Position { get; set; }
    public short? DrawingLength { get; set; }
    public short? Addition { get; set; }
    public short? TechnologicalAddition { get; set; }
    public string? Stage { get; set; }
    public string? Comment { get; set; }
    public short? D15I { get; set; }
    public short? D15II { get; set; }
    public short? D1I { get; set; }
    public short? D1II { get; set; }
    public short PrefabricationQuantity { get; set; }
    public short PrefabricationLength { get; set; }
    public double PrefabricationWeight { get; set; }
    public short AssemblyQuantity { get; set; }
    public short AssemblyLength { get; set; }
    public double AssemblyWeight { get; set; }
    public IsoReadModel Iso { get; set; }
    public AssortmentDictionaryReadModel StandardNumber { get; set; }
}
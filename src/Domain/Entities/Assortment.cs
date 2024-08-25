using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class Assortment : BaseEntity
{
    public required string Name { get; set; }
    public char Position { get; set; }
    public ushort? DrawingLength { get; set; }
    public ushort? Addition { get; set; }
    public ushort? TechnologicalAddition { get; set; }
    public char? Stage { get; set; }
    public ushort? D15I {get; set;}
    public ushort? D15II {get; set;}
    public ushort? D1I {get; set;}
    public ushort? D1II {get; set;}
    public ushort PrefabricationQuantity { get; set; }
    public ushort PrefabricationLength { get; set; }
    public double PrefabricationWeight { get; set; }
    public ushort AssemblyQuantity { get; set; }
    public ushort AssemblyLength { get; set; }
    public double AssemblyWeight { get; set; }
    public string? Comment { get; set; }
    public Iso? Iso { get; set; }
    public AssortmentDictionary? AssortmentDictionary { get; set; }
}

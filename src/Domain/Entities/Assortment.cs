using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class Assortment : BaseAuditableEntity
{
    public char Position { get; set; }
    public ushort PrefabricationQuantity { get; set; }
    public ushort PrefabricationLength { get; set; }
    public double PrefabricationWeight { get; set; }
    public ushort AssemblyQuantity { get; set; }
    public ushort AssemblyLength { get; set; }
    public double AssemblyWeight { get; set; }
    public char PG { get; set; }
    public string? ValveNumber { get; set; }
    public string? CutAngle { get; set; }
    public string? Comment { get; set; }
    public Iso? Iso { get; set; }
    public AssortmentDictionary? AssortmentDictionary { get; set; }
}

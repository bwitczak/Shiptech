namespace Shiptech.Infrastructure.EF.Models;

internal class AssortmentReadModel
{
    public string Id { get; set; }
    public string Position { get; set; }
    public int? DrawingLength { get; set; }
    public int? Addition { get; set; }
    public int? TechnologicalAddition { get; set; }
    public string? Stage { get; set; }
    public int? D15I { get; set; }
    public int? D15II { get; set; }
    public int? D1I { get; set; }
    public int? D1II { get; set; }
    public int PrefabricationQuantity { get; set; }
    public int PrefabricationLength { get; set; }
    public double PrefabricationWeight { get; set; }
    public int AssemblyQuantity { get; set; }
    public int AssemblyLength { get; set; }
    public double AssemblyWeight { get; set; }
    public IsoReadModel Iso { get; set; }
}
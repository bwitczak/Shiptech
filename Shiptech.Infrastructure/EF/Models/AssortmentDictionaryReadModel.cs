namespace Shiptech.Infrastructure.EF.Models;

internal class AssortmentDictionaryReadModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Distinguishing { get; set; }
    public string Unit { get; set; }
    public double Amount { get; set; }
    public double Weight { get; set; }
    public string? Material { get; set; }
    public string? Kind { get; set; }
    public double? Length { get; set; }
    public string RO { get; set; }
    public string? Comment { get; set; }
    public IEnumerable<AssortmentReadModel> Assortments { get; set; }
}
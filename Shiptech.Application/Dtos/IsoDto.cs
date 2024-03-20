namespace Shiptech.Application.Dtos;

public class IsoDto
{
    public string Id { get; set; }
    public string IsoRevision { get; set; }
    public string System { get; set; }
    public string Class { get; set; }
    public bool? Atest { get; set; }
    public string? KzmNumber { get; set; }
    public string? KzmDate { get; set; }
    public ChemicalProcessDto ChemicalProcess { get; set; }
    public IEnumerable<AssortmentDto> Assortments { get; set; }
}
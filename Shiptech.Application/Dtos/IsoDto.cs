namespace Shiptech.Application.Dtos;

public class IsoDto
{
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public char IsoRevision { get; set; }
    public string System { get; set; }
    public string Class { get; set; }
    public string? Atest { get; set; }
    public string? KzmNumber { get; set; }
    public DateTime? KzmDate { get; set; }
    public ChemicalProcessDto ChemicalProcess { get; set; }
    public IEnumerable<AssortmentDto> Assortments { get; set; }
}
namespace Shiptech.Application.Dtos;

public class DrawingDto
{
    public string Id { get; set; }
    public string DrawingRevision { get; set; }
    public string? Lot { get; set; }
    public string? Block { get; set; }
    public string? Section { get; set; }
    public string? Stage { get; set; }
    public string Date { get; set; }
    public string Author { get; set; }
    public IEnumerable<IsoDto> Isos { get; set; }
}
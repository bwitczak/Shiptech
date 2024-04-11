namespace Shiptech.Application.Dtos;

public class DrawingDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public char DrawingRevision { get; set; }
    public string? Lot { get; set; }
    public string? Block { get; set; }
    public List<string>? Section { get; set; }
    public string? Stage { get; set; }
    public DateTime CreationDate { get; set; }
    public string Author { get; set; }
    public IEnumerable<IsoDto> Isos { get; set; }
}
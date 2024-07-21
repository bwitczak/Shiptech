namespace Shiptech.Application.Dtos;

public class DrawingWithNoRelationsDto
{
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public string DrawingRevision { get; set; }
    public string? Lot { get; set; }
    public string? Block { get; set; }
    public List<string>? Section { get; set; }
    public string? Stage { get; set; }
    public string CreationDate { get; set; }
    public string Author { get; set; }
}
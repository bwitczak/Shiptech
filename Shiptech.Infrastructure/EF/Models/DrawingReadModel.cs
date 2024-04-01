using Shiptech.Infrastructure.EF.Models.Consts;

namespace Shiptech.Infrastructure.EF.Models;

internal class DrawingReadModel
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
    public ShipReadModel Ship { get; set; }
    public ICollection<IsoReadModel> Isos { get; set; }
}
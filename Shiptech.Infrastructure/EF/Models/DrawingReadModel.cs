using Shiptech.Infrastructure.EF.Models.Consts;

namespace Shiptech.Infrastructure.EF.Models;

internal class DrawingReadModel
{
    public string Id { get; set; }
    public string DrawingRevision { get; set; }
    public string? Lot { get; set; }
    public string? Block { get; set; }
    public string? Section { get; set; }
    public StageEnum? Stage { get; set; }
    public string Date { get; set; } // TODO: Change string to DateTime
    public string Author { get; set; }
    public ShipReadModel Ship { get; set; }
    public ICollection<IsoReadModel> Isos { get; set; }
}
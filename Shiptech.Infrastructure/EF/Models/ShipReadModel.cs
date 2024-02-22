namespace Shiptech.Infrastructure.EF.Models;

internal class ShipReadModel
{
    public string Id { get; set; }
    public string Orderer { get; set; }
    public ICollection<DrawingReadModel> Drawings { get; set; }
}
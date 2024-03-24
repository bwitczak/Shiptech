namespace Shiptech.Infrastructure.EF.Models;

internal class ShipReadModel
{
    public Guid Id { get; set; }
    public string Orderer { get; set; }
    public ICollection<DrawingReadModel> Drawings { get; set; }
}
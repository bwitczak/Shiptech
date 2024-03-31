namespace Shiptech.Application.Dtos;

public class ShipDto
{
    public Guid Id { get; set; }
    public string Orderer { get; set; }
    public IEnumerable<DrawingDto> Drawings { get; set; }
}
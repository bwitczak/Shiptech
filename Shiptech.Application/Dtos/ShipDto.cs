namespace Shiptech.Application.Dtos;

public class ShipDto
{
    public Ulid Id { get; set; }
    public string Code { get; set; }
    public string Orderer { get; set; }
    public IEnumerable<DrawingWithNoRelationsDto> Drawings { get; set; }
}
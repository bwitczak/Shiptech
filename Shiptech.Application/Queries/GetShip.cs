using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetShip : IQuery<ShipDto>
{
    public Guid Id { get; set; }
    public int DrawingPageSize { get; set; }
    public int DrawingPageNumber { get; set; }
}
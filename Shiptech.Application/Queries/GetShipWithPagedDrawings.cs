using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetShipWithPagedDrawings : IQuery<ShipDto>
{
    public Ulid Id { get; set; }
    public int DrawingPageSize { get; set; }
    public int DrawingPageNumber { get; set; }
}
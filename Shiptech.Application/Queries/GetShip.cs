using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetShip : IQuery<ShipDto>
{
    public string Id { get; set; }
}
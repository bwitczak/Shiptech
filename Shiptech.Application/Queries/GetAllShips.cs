using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetAllShips : IQuery<IEnumerable<ShipDto>>
{
}
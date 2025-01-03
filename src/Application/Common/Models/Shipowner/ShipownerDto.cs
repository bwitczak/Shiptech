using AutoMapper;
using Shiptech.Application.Common.Models.Ship;

namespace Shiptech.Application.Common.Models.Shipowner;

public class ShipownerDto
{
    public Ulid Id { get; init; }
    public required string Orderer { get; init; }
    public IList<ShipWithNoRelationsDto> Ships { get; init; } = new List<ShipWithNoRelationsDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Shipowner, ShipownerDto>();
        }
    }
}

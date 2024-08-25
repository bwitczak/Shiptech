using AutoMapper;

namespace Shiptech.Application.Common.Models.Ship;

public class ShipWithNoRelationsDto()
{
    public Ulid Id { get; init; }
    public required string Code { get; init; }
    public required string Orderer { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Ship, ShipWithNoRelationsDto>();
        }
    }
}

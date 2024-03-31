using AutoMapper;
using Shiptech.Application.Dtos;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.AutoMapper;

public class MappingProfile : Profile
{
    internal MappingProfile()
    {
        CreateMap<ShipDto, ShipReadModel>();
        CreateMap<ShipReadModel, ShipDto>();
        
        CreateMap<ShipWithNoRelationsDto, ShipReadModel>();
        CreateMap<ShipReadModel, ShipWithNoRelationsDto>();
        
        CreateMap<DrawingWithNoRelationsDto, DrawingReadModel>();
        CreateMap<DrawingReadModel, DrawingWithNoRelationsDto>();
        
        CreateMap<DrawingDto, DrawingReadModel>().ForMember(
            x => x.Isos,
            x => x.Ignore());
        CreateMap<DrawingReadModel, DrawingDto>();
    }
}
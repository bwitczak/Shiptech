using AutoMapper;

namespace Shiptech.Application.Common.Models.ChemicalProcess;

public class ChemicalProcessDto
{
    public Ulid Id { get; set; }
    public required string ChemicalProcessCode { get; set; }
    public required string ChemicalProcessName { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.ChemicalProcess, ChemicalProcessDto>()
                .ForMember(x => x.ChemicalProcessCode, opt => opt.MapFrom(x => x.Code))
                .ForMember(x => x.ChemicalProcessName, opt => opt.MapFrom(x => x.Name));
        }
    }
}

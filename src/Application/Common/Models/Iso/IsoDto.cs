using AutoMapper;
using Shiptech.Application.Common.Models.Assortment;
using Shiptech.Application.Common.Models.ChemicalProcess;

namespace Shiptech.Application.Common.Models.Iso;

public class IsoDto
{
    public Ulid Id { get; init; }
    public required string Number { get; init; }
    public required string Nameplate { get; init; }
    public required string IsoRevision { get; init; }
    public required string System { get; init; }
    public required string Class { get; init; }
    public string? Atest { get; init; }
    public string? KzmNumber { get; init; }
    public string? KzmDate { get; init; }
    public ChemicalProcessDto? ChemicalProcess { get; init; }
    public IList<AssortmentDto> Assortments { get; init; } = new List<AssortmentDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Iso, IsoDto>()
                .ForMember(x => x.IsoRevision, opt => opt.MapFrom(src => src.Revision));
        }
    }
}

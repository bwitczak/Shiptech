using AutoMapper;
using Shiptech.Application.Common.Models.Iso;

namespace Shiptech.Application.Common.Models.Drawing;

public class DrawingDto
{
    public Ulid Id { get; init; }
    public required string Number { get; init; }
    public required string Name { get; init; }
    public required string DrawingRevision { get; init; }
    public string? Lot { get; init; }
    public string? Block { get; init; }
    public List<string>? Section { get; init; }
    public string? Stage { get; init; }
    public DateTime CreationDate { get; init; }
    public required string CreatedBy { get; init; }
    public IList<IsoDto> Isos { get; init; } = new List<IsoDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Drawing, DrawingDto>()
                .ForMember(x => x.DrawingRevision, opt => opt.MapFrom(src => src.Revision));
        }
    }
}

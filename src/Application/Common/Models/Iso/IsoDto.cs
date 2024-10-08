using AutoMapper;
using Shiptech.Application.Common.Models.Assortment;
using Shiptech.Application.Common.Models.ChemicalProcess;

namespace Shiptech.Application.Common.Models.Iso;

public class IsoDto
{
    public Ulid Id { get; set; }
    public required string Number { get; set; }
    public required string Nameplate { get; set; }
    public char IsoRevision { get; set; }
    public required string System { get; set; }
    public required string Class { get; set; }
    public string? Atest { get; set; }
    public string? KzmNumber { get; set; }
    public DateOnly? KzmDate { get; set; }
    public ChemicalProcessDto? ChemicalProcess { get; set; }
    public IList<AssortmentDto> Assortments { get; set; } = new List<AssortmentDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Iso, IsoDto>();
        }
    }
}

using AutoMapper;
using Shiptech.Application.Common.Models.Iso;
using Shiptech.Application.Common.Models.Ship;

namespace Shiptech.Application.Common.Models.Drawing;

public class DrawingDto
{
    public Ulid Id { get; set; }
    public required string Number { get; set; }
    public required string Name { get; set; }
    public char DrawingRevision { get; set; }
    public string? Lot { get; set; }
    public string? Block { get; set; }
    public List<string>? Section { get; set; }
    public string? Stage { get; set; }
    public DateTime CreationDate { get; set; }
    public required string CreatedBy { get; set; }
    public IList<IsoDto> Isos { get; set; } = new List<IsoDto>();
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Drawing, DrawingDto>();
        }
    }
}
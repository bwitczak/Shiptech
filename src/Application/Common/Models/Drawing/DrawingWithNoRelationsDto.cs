using AutoMapper;

namespace Shiptech.Application.Common.Models.Drawing;

public class DrawingWithNoRelationsDto
{
    public Ulid Id { get; init; }
    public required string Number { get; init; }
    public required string Name { get; init; }
    public required string DrawingRevision { get; init; }
    public string? Lot { get; init; }
    public string? Block { get; init; }
    public List<string>? Section { get; init; }
    public string? Stage { get; init; }
    public required string CreatedBy { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Drawing, DrawingWithNoRelationsDto>();
        }
    }
}

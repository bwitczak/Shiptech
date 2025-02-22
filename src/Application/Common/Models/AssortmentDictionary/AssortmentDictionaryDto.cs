using AutoMapper;

namespace Shiptech.Application.Common.Models.AssortmentDictionary;

public class AssortmentDictionaryDto
{
    public Ulid Id { get; init; }
    public required string Number { get; init; }
    public required string Name { get; init; }
    public string? Distinguishing { get; init; }
    public required string Unit { get; init; }
    public double? Amount { get; init; }
    public double? Weight { get; init; }
    public string? Material { get; init; }
    public string? Kind { get; init; }
    public string? DN1 { get; init; }
    public string? DN2 { get; init; }
    public ushort? Length { get; init; }
    public string? RA { get; init; }
    public string? NS { get; init; }
    public string? Comment { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.AssortmentDictionary, AssortmentDictionaryDto>();
        }
    }
}

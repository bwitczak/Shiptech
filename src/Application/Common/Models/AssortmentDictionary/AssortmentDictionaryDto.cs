using AutoMapper;
using Shiptech.Application.Common.Models.Drawing;

namespace Shiptech.Application.Common.Models.AssortmentDictionary;

public class AssortmentDictionaryDto
{
    public Ulid Id { get; set; }
    public required string Number { get; set; }
    public required string Name { get; set; }
    public required string Distinguishing { get; set; }
    public required string Unit { get; set; }
    public double? Amount { get; set; }
    public double? Weight { get; set; }
    public string? Material { get; set; }
    public string? Kind { get; set; }
    public string? DN1 { get; set; }
    public string? DN2 { get; set; }
    public double? Length { get; set; }
    public required string RO { get; set; }
    public string? Comment { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.AssortmentDictionary, AssortmentDictionaryDto>();
        }
    }
}

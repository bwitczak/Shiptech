using AutoMapper;
using Shiptech.Application.Common.Models.AssortmentDictionary;

namespace Shiptech.Application.Common.Models.Assortment;

public class AssortmentDto
{
    public Ulid Id { get; init; }
    public char Position { get; init; }
    public ushort PrefabricationQuantity { get; init; }
    public ushort PrefabricationLength { get; init; }
    public double PrefabricationWeight { get; init; }
    public ushort AssemblyQuantity { get; init; }
    public ushort AssemblyLength { get; init; }
    public double AssemblyWeight { get; init; }
    public char PG { get; init; }
    public string? ValveNumber { get; init; }
    public string? CutAngle { get; init; }
    public string? Comment { get; init; }
    public AssortmentDictionaryDto? AssortmentDictionaryDto { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Assortment, AssortmentDto>();
        }
    }
}

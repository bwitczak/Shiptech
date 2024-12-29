using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class AssortmentFactory : IAssortmentFactory
{
    public Assortment Create(Ulid id, char position, ushort prefabricationQuantity,
        ushort prefabricationLength, double prefabricationWeight, ushort assemblyQuantity, ushort assemblyLength,
        double assemblyWeight, char pg, string? valveNumber, string? cutAngle, string? comment, Iso iso,
        AssortmentDictionary assortmentDictionary)
    {
        return new Assortment
        {
            Id = id,
            Position = position,
            PrefabricationQuantity = prefabricationQuantity,
            PrefabricationLength = prefabricationLength,
            PrefabricationWeight = prefabricationWeight,
            AssemblyQuantity = assemblyQuantity,
            AssemblyLength = assemblyLength,
            AssemblyWeight = assemblyWeight,
            PG = pg,
            ValveNumber = valveNumber,
            CutAngle = cutAngle,
            Comment = comment,
            Iso = iso,
            AssortmentDictionary = assortmentDictionary
        };
    }
}

using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IAssortmentFactory
{
    Assortment Create(Ulid id, char position, ushort prefabricationQuantity, ushort prefabricationLength,
        double prefabricationWeight, ushort assemblyQuantity, ushort assemblyLength, double assemblyWeight,
        char pg, string? valveNumber, string? cutAngle, string? comment, Iso iso,
        AssortmentDictionary assortmentDictionary);
}

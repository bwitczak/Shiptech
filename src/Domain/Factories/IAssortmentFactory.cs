using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IAssortmentFactory
{
    Assortment Create(Ulid id, string name, char position, ushort? drawingLength, ushort? addition,
        ushort? technologicalAddition, char? stage, ushort? d15I, ushort? d15Ii, ushort? d1I, ushort? d1Ii,
        ushort prefabricationQuantity, ushort prefabricationLength, double prefabricationWeight,
        ushort assemblyQuantity, ushort assemblyLength, double assemblyWeight, string? comment, Iso iso, AssortmentDictionary assortmentDictionary);
}

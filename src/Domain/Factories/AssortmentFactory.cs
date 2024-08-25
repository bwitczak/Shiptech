using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class AssortmentFactory : IAssortmentFactory
{
    public Assortment Create(Ulid id, string name, char position, ushort? drawingLength, ushort? addition, ushort? technologicalAddition,
        char? stage, ushort? d15I, ushort? d15Ii, ushort? d1I, ushort? d1Ii, ushort prefabricationQuantity,
        ushort prefabricationLength, double prefabricationWeight, ushort assemblyQuantity, ushort assemblyLength,
        double assemblyWeight, string? comment, Iso iso, AssortmentDictionary assortmentDictionary)
    {
        return new Assortment {Id = id, Name = name, Position = position, DrawingLength = drawingLength, 
            Addition = addition, TechnologicalAddition = technologicalAddition, Stage = stage, D15I = d15I, D15II = d15Ii,
            D1I = d1I, D1II = d1Ii, PrefabricationQuantity = prefabricationQuantity, PrefabricationLength = prefabricationLength,
            PrefabricationWeight = prefabricationWeight, AssemblyQuantity = assemblyQuantity, AssemblyLength = assemblyLength,
            AssemblyWeight = assemblyWeight, Comment = comment, Iso = iso, AssortmentDictionary = assortmentDictionary
        };
    }
}

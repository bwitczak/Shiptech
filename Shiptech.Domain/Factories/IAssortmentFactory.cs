using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IAssortmentFactory
    {
        Assortment Create(AssortmentId id, Position position, DrawingLength drawingLength, Addition addition,
            TechnologicalAddition technologicalAddition, AssortmentStage stage, D15I d15I, D15II d15II, D1I d1I, D1II d1II,
            PrefabricationQuantity prefabricationQuantity, PrefabricationLength prefabricationLength, PrefabricationWeight prefabricationWeight,
            AssemblyQuantity assemblyQuantity, AssemblyLength assemblyLength, AssemblyWeight assemblyWeight);
    }
}
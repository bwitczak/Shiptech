using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class AssortmentFactory : IAssortmentFactory
    {
        public Assortment Create(AssortmentId id, Position position, DrawingLength drawingLength, Addition addition, TechnologicalAddition technologicalAddition, AssortmentStage stage, Comment comment ,D15I d15I, D15II d15II, D1I d1I, D1II d1II, PrefabricationQuantity prefabricationQuantity, PrefabricationLength prefabricationLength, PrefabricationWeight prefabricationWeight, AssemblyQuantity assemblyQuantity, AssemblyLength assemblyLength, AssemblyWeight assemblyWeight)
            => new(id, position, drawingLength, addition, technologicalAddition, stage, comment, d15I, d15II, d1I, d1II, prefabricationQuantity, prefabricationLength, prefabricationWeight, assemblyQuantity, assemblyLength, assemblyWeight);
    }
}
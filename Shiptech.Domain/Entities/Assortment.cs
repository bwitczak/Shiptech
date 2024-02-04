using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public class Assortment
    {
        public AssortmentId Id { get; private set; }
        private Position _position;
        private DrawingLength _drawingLength;
        private Addition _addition;
        private TechnologicalAddition _technologicalAddition;
        private AssortmentStage _stage;
        private D15I _d15I;
        private D15II _d15II;
        private D1I _d1I;
        private D1II _d1II;
        private PrefabricationQuantity _prefabricationQuantity;
        private PrefabricationLength _prefabricationLength;
        private PrefabricationWeight _prefabricationWeight;
        private AssemblyQuantity _assemblyQuantity;
        private AssemblyLength _assemblyLength;
        private AssemblyWeight _assemblyWeight;

        internal Assortment(AssortmentId id, Position position, DrawingLength drawingLength, Addition addition,
            TechnologicalAddition technologicalAddition, AssortmentStage stage, D15I d15I, D15II d15II, D1I d1I, D1II d1II,
            PrefabricationQuantity prefabricationQuantity, PrefabricationLength prefabricationLength, PrefabricationWeight prefabricationWeight,
            AssemblyQuantity assemblyQuantity, AssemblyLength assemblyLength, AssemblyWeight assemblyWeight)
        {
            Id = id;
            _position = position;
            _drawingLength = drawingLength;
            _addition = addition;
            _technologicalAddition = technologicalAddition;
            _stage = stage;
            _d15I = d15I;
            _d15II = d15II;
            _d1I = d1I;
            _d1II = d1II;
            _prefabricationQuantity = prefabricationQuantity;
            _prefabricationLength = prefabricationLength;
            _prefabricationWeight = prefabricationWeight;
            _assemblyQuantity = assemblyQuantity;
            _assemblyLength = assemblyLength;
            _assemblyWeight = assemblyWeight;
        }
    }
}
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class ChemicalProcessFactory : IChemicalProcessFactory
    {
        public ChemicalProcess Create(Id id, ChemicalProcessCode code, ChemicalProcessName chemicalProcessName)
            => new(id, code, chemicalProcessName);
    }
}
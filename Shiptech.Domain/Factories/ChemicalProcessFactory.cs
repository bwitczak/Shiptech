using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class ChemicalProcessFactory : IChemicalProcessFactory
    {
        public ChemicalProcess Create(ChemicalProcessId id, ChemicalProcessName chemicalProcessName)
            => new(id, chemicalProcessName);
    }
}
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IChemicalProcessFactory
    {
        ChemicalProcess Create(ChemicalProcessId id, ChemicalProcessName chemicalProcessName);
    }
}
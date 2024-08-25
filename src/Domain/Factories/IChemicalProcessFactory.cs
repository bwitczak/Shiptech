using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IChemicalProcessFactory
{
    ChemicalProcess Create(Ulid id, string code, string name);
}

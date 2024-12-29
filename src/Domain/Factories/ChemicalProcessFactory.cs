using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class ChemicalProcessFactory : IChemicalProcessFactory
{
    public ChemicalProcess Create(Ulid id, string code, string name)
    {
        return new ChemicalProcess { Id = id, Code = code, Name = name };
    }
}

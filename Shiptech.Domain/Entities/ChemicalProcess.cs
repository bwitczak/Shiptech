using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities;

public class ChemicalProcess
{
    public ChemicalProcessId Id { get; private set; }
    private ChemicalProcessName _chemicalProcessName;

    internal ChemicalProcess(ChemicalProcessId id, ChemicalProcessName chemicalProcessName)
    {
        Id = id;
        _chemicalProcessName = chemicalProcessName;
    }
}


using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities;

public class ChemicalProcess
{
    public ChemicalProcessId Id { get; private set; }
    private ChemicalProcessName _chemicalProcessName;
    private IEnumerable<ChemicalProcess> _chemicalProcesses;

    private ChemicalProcess()
    {
    }

    internal ChemicalProcess(ChemicalProcessId id, ChemicalProcessName chemicalProcessName)
    {
        Id = id;
        _chemicalProcessName = chemicalProcessName;
    }
}
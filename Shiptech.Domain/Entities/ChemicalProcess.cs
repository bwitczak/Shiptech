using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities;

public class ChemicalProcess
{
    public Id Id { get; private set; }
    private ChemicalProcessCode _chemicalProcessCode;
    private ChemicalProcessName _chemicalProcessName;

    private ChemicalProcess()
    {
    }

    internal ChemicalProcess(Id id, ChemicalProcessCode code, ChemicalProcessName chemicalProcessName)
    {
        Id = id;
        _chemicalProcessCode = code;
        _chemicalProcessName = chemicalProcessName;
    }
}
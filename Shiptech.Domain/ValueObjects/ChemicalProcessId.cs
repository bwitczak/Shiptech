using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record ChemicalProcessId(string Value)
    {
        public static implicit operator string(ChemicalProcessId chemicalProcessId) => chemicalProcessId.Value;
        public static implicit operator ChemicalProcessId(string chemicalProcessId) => new(chemicalProcessId);
    }
}
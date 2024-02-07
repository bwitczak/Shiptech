using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record ChemicalProcessId
    {
        public string Value { get; }

        public ChemicalProcessId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullChemicalProcessIdException();
            }

            Value = value;
        }

        public static implicit operator string(ChemicalProcessId chemicalProcessId) => chemicalProcessId.Value;
        public static implicit operator ChemicalProcessId(string chemicalProcessId) => new(chemicalProcessId);
    }
}
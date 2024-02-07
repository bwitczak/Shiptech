using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record ChemicalProcessName
    {
        public string Value { get; }

        public ChemicalProcessName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullChemicalProcessNameException();
            }

            Value = value;
        }

        public static implicit operator string(ChemicalProcessName chemicalProcessName) => chemicalProcessName.Value;
        public static implicit operator ChemicalProcessName(string chemicalProcessName) => new(chemicalProcessName);
    }
}
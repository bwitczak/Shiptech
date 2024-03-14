namespace Shiptech.Domain.ValueObjects
{
    public record ChemicalProcessName(string Value)
    {
        public static implicit operator string(ChemicalProcessName chemicalProcessName) => chemicalProcessName.Value;
        public static implicit operator ChemicalProcessName(string chemicalProcessName) => new(chemicalProcessName);
    }
}
namespace Shiptech.Domain.ValueObjects
{
    public record ChemicalProcessCode(string Value)
    {
        public static implicit operator string(ChemicalProcessCode chemicalProcessCode) => chemicalProcessCode.Value;
        public static implicit operator ChemicalProcessCode(string chemicalProcessId) => new(chemicalProcessId);
    }
}
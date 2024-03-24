namespace Shiptech.Domain.ValueObjects
{
    public record TechnologicalAddition(ushort? Value)
    {
        public static implicit operator ushort?(TechnologicalAddition technologicalAddition) => technologicalAddition.Value;
        public static implicit operator TechnologicalAddition(ushort? technologicalAddition) => new(technologicalAddition);
    }
}
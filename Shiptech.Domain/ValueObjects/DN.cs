namespace Shiptech.Domain.ValueObjects
{
    public record DN(ushort? Value)
    {
        public static implicit operator ushort?(DN addition) => addition.Value;
        public static implicit operator DN(ushort? addition) => new(addition);
    }
}
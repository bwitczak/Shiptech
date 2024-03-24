namespace Shiptech.Domain.ValueObjects
{
    public record D15I(ushort? Value)
    {
        public static implicit operator ushort?(D15I d15I) => d15I.Value;
        public static implicit operator D15I(ushort? d15I) => new(d15I);
    }
}
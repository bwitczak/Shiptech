namespace Shiptech.Domain.ValueObjects
{
    public record D1I(ushort? Value)
    {
        public static implicit operator ushort?(D1I d1I) => d1I.Value;
        public static implicit operator D1I(ushort? d1I) => new(d1I);
    }
}
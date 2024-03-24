namespace Shiptech.Domain.ValueObjects
{
    public record D1II(ushort? Value)
    {
        public static implicit operator ushort?(D1II d1II) => d1II.Value;
        public static implicit operator D1II(ushort? d1II) => new(d1II);
    }
}
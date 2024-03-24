namespace Shiptech.Domain.ValueObjects
{
    public record D15II(ushort? Value)
    {
        public static implicit operator ushort?(D15II d15II) => d15II.Value;
        public static implicit operator D15II(ushort? d15II) => new(d15II);
    }
}
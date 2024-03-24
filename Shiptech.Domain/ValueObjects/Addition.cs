namespace Shiptech.Domain.ValueObjects
{
    public record Addition(ushort? Value)
    {
        public static implicit operator ushort?(Addition addition) => addition.Value;
        public static implicit operator Addition(ushort? addition) => new(addition);
    }
}
namespace Shiptech.Domain.ValueObjects
{
    public record DN(string? Value)
    {
        public static implicit operator string?(DN addition) => addition.Value;
        public static implicit operator DN(string? addition) => new(addition);
    }
}
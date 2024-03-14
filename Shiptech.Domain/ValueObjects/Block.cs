namespace Shiptech.Domain.ValueObjects
{
    public record Block(string? Value)
    {
        public static implicit operator string?(Block block) => block.Value;
        public static implicit operator Block(string? block) => new(block);
    }
}
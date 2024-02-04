using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Block
    {
        public string Value { get; }

        public Block(string value)
        {
            if (int.TryParse(value, out var number))
            {
                if (number is < 100 or > 999)
                {
                    throw new InvalidBlockValueException(value);
                }
            }

            Value = value;
        }

        public static implicit operator string(Block block) => block.Value;
        public static implicit operator Block(string block) => new(block);
    }
}
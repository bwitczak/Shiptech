using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Addition
    {
        public int? Value { get; }

        public Addition(int? value)
        {
            if (value is < 0)
            {
                throw new InvalidAdditionValueException(value);
            }

            Value = value;
        }

        public static implicit operator int?(Addition addition) => addition.Value;
        public static implicit operator Addition(int? addition) => new(addition);
    }
}
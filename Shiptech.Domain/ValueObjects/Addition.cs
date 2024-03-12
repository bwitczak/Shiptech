using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Addition
    {
        public short? Value { get; }

        public Addition(short? value)
        {
            if (value is < 0)
            {
                throw new InvalidAdditionValueException(value);
            }

            Value = value;
        }

        public static implicit operator short?(Addition addition) => addition.Value;
        public static implicit operator Addition(short? addition) => new(addition);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Position
    {
        public string Value { get; }

        public Position(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullPositionException();
            }

            if (value.Length != 1)
            {
                throw new InvalidPositionLengthException(value);
            }

            Value = value;
        }

        public static implicit operator string(Position position) => position.Value;
        public static implicit operator Position(string position) => new(position);
    }
}
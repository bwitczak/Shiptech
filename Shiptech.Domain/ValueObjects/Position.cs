using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Position
    {
        public char Value { get; }

        public Position(char value)
        {
            if (char.IsLetter(value))
            {
                throw new EmptyOrNullPositionException();
            }

            // if (value.Length != 1)
            // {
            //     throw new InvalidPositionLengthException(value);
            // }

            Value = value;
        }

        public static implicit operator char(Position position) => position.Value;
        public static implicit operator Position(char position) => new(position);
    }
}
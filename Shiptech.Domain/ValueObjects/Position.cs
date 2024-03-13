using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Position(char Value)
    {
        public static implicit operator char(Position position) => position.Value;
        public static implicit operator Position(char position) => new(position);
    }
}
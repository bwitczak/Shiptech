using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Addition(short? Value)
    {
        public static implicit operator short?(Addition addition) => addition.Value;
        public static implicit operator Addition(short? addition) => new(addition);
    }
}
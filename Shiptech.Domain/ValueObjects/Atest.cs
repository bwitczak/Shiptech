using Shiptech.Domain.Consts;
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Atest
    {
        public string? Value { get; }

        public Atest(string? value)
        {
            // if (!value.HasFlag(value))
            // {
            //     throw new InvalidAtestValueException(value);
            // }

            Value = value;
        }

        public static implicit operator string?(Atest atest) => atest.Value;
        public static implicit operator Atest(string? atest) => new(atest);
    }
}
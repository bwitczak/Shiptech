using Shiptech.Domain.Consts;
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Atest
    {
        public AtestEnum Value { get; }

        public Atest(AtestEnum value)
        {
            if (!value.HasFlag(value))
            {
                throw new InvalidAtestValueException(value);
            }

            Value = value;
        }

        public static implicit operator AtestEnum(Atest atest) => atest.Value;
        public static implicit operator Atest(AtestEnum atest) => new(atest);
    }
}
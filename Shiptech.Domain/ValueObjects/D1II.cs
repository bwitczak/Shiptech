using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D1II
    {
        public int? Value { get; }

        public D1II(int? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD1IIValueException(value);
            }

            Value = value;
        }

        public static implicit operator int?(D1II d1II) => d1II.Value;
        public static implicit operator D1II(int? d1II) => new(d1II);
    }
}
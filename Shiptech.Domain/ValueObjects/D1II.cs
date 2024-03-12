using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D1II
    {
        public short? Value { get; }

        public D1II(short? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD1IIValueException(value);
            }

            Value = value;
        }

        public static implicit operator short?(D1II d1II) => d1II.Value;
        public static implicit operator D1II(short? d1II) => new(d1II);
    }
}
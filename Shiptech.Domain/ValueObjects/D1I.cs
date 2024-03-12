using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D1I
    {
        public short? Value { get; }

        public D1I(short? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD1IValueException(value);
            }

            Value = value;
        }

        public static implicit operator short?(D1I d1I) => d1I.Value;
        public static implicit operator D1I(short? d1I) => new(d1I);
    }
}
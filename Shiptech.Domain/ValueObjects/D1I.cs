using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D1I
    {
        public int? Value { get; }

        public D1I(int? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD1IValueException(value);
            }

            Value = value;
        }

        public static implicit operator int?(D1I d1I) => d1I.Value;
        public static implicit operator D1I(int? d1I) => new(d1I);
    }
}
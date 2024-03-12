using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D15I
    {
        public short? Value { get; }

        public D15I(short? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD15IValueException(value);
            }

            Value = value;
        }

        public static implicit operator short?(D15I d15I) => d15I.Value;
        public static implicit operator D15I(short? d15I) => new(d15I);
    }
}
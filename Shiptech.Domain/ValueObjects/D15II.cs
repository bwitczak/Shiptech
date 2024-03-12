using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D15II
    {
        public short? Value { get; }

        public D15II(short? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD15IIValueException(value);
            }

            Value = value;
        }

        public static implicit operator short?(D15II d15II) => d15II.Value;
        public static implicit operator D15II(short? d15II) => new(d15II);
    }
}
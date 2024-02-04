using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D15II
    {
        public int? Value { get; }

        public D15II(int? value)
        {
            if (value is < 0 or > 90)
            {
                throw new InvalidD15IIValueException(value);
            }

            Value = value;
        }

        public static implicit operator int?(D15II d15II) => d15II.Value;
        public static implicit operator D15II(int? d15II) => new(d15II);
    }
}
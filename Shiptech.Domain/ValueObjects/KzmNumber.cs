using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record KzmNumber
    {
        public string? Value { get; }

        public KzmNumber(string value)
        {
            if (value != null && value.Length != 6)
            {
                throw new InvalidKzmNumberLengthException(value);
            }

            Value = value;
        }

        public static implicit operator string?(KzmNumber kzmNumber) => kzmNumber.Value;
        public static implicit operator KzmNumber(string kzmNumber) => new(kzmNumber);
    }
}
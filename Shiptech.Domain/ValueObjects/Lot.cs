using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Lot
    {
        public string? Value { get; }

        public Lot(string? value)
        {
            if (int.TryParse(value, out var number))
            {
                if (number is < 100 or > 999)
                {
                    throw new InvalidLotValueException(value);
                }
            }

            Value = value;
        }

        public static implicit operator string?(Lot lot) => lot.Value;
        public static implicit operator Lot(string? lot) => new(lot);
    }
}
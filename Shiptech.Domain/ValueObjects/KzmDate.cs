using System.Globalization;

namespace Shiptech.Domain.ValueObjects
{
    public record KzmDate
    {
        public DateTime? Value { get; }

        public KzmDate(DateTime? value)
        {
            Value = value;
        }

        public static implicit operator DateTime?(KzmDate date) => date.Value;
        public static implicit operator KzmDate(DateTime? date) => new (date);
    }
}
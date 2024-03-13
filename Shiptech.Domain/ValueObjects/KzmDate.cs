using System.Globalization;

namespace Shiptech.Domain.ValueObjects
{
    public record KzmDate(DateTime? Value)
    {
        public static implicit operator DateTime?(KzmDate date) => date.Value;
        public static implicit operator KzmDate(DateTime? date) => new (date);
    }
}
using System.Globalization;

namespace Shiptech.Domain.ValueObjects
{
    public record CreationDate
    {
        public DateTime Value { get; }

        public CreationDate(DateTime value)
        {
            Value = value;
        }

        public static implicit operator DateTime(CreationDate date) => date.Value;
        public static implicit operator CreationDate(DateTime date) => new (date);
    }
}
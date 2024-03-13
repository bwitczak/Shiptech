using System.Globalization;

namespace Shiptech.Domain.ValueObjects
{
    public record CreationDate(DateTime Value)
    {
        public static implicit operator DateTime(CreationDate date) => date.Value;
        public static implicit operator CreationDate(DateTime date) => new (date);
    }
}
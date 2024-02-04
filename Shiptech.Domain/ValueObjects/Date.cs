using System.Globalization;

namespace Shiptech.Domain.ValueObjects
{
    public record Date
    {
        public string? Value { get; }

        public Date(string? value)
        {
            if (value != null)
            {
                Value = DateTime.Parse(value).ToString("g", CultureInfo.CreateSpecificCulture("pl-PL"));
                return;
            }

            Value = null;
        }

        public static implicit operator string?(Date date) => date.Value;
        public static implicit operator Date(string date) => new(date);
    }
}
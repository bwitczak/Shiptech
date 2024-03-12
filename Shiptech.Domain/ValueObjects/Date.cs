using System.Globalization;

namespace Shiptech.Domain.ValueObjects
{
    public record Date
    {
        public DateTime? Value { get; }

        public Date(DateTime? value)
        {
            // if (value != null)
            // {
            //     Value = DateTime.Parse(value).ToString("g", CultureInfo.CreateSpecificCulture("pl-PL"));
            //     return;
            // }

            Value = value;
        }

        public static implicit operator DateTime?(Date date) => date.Value;
        public static implicit operator Date(DateTime date) =>
            DateTime.Parse(date.ToShortTimeString());
    }
}
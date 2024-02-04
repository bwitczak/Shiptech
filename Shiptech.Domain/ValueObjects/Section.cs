using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Section
    {
        public string Value { get; }

        public Section(string value)
        {
            if (int.TryParse(value, out var number))
            {
                if (number is < 999 or > 9999)
                {
                    throw new InvalidSectionValueException(value);
                }
            }

            Value = value;
        }

        public static implicit operator string(Section section) => section.Value;
        public static implicit operator Section(string section) => new(section);
    }
}
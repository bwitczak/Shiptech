using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Class
    {
        public string Value { get; }

        public Class(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullClassException();
            }

            if (value.Length != 6)
            {
                throw new InvalidClassLengthException(value);
            }

            Value = value;
        }

        public static implicit operator string(Class @class) => @class.Value;
        public static implicit operator Class(string @class) => new(@class);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Author
    {
        public string Value { get; }

        public Author(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullAuthorException();
            }

            Value = value;
        }

        public static implicit operator string(Author author) => author.Value;
        public static implicit operator Author(string author) => new(author);
    }
}
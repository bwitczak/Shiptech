namespace Shiptech.Domain.ValueObjects
{
    public record Author(string Value)
    {
        public static implicit operator string(Author author) => author.Value;
        public static implicit operator Author(string author) => new(author);
    }
}
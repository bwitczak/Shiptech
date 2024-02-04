using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Revision
    {
        public string Value { get; }

        public Revision(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullRevisionException();
            }

            if (value.Length != 1)
            {
                throw new InvalidRevisionLengthException(value);
            }

            Value = value;
        }

        public static implicit operator string(Revision revision) => revision.Value;
        public static implicit operator Revision(string revision) => new(revision);
    }
}
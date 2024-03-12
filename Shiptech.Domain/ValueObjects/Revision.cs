using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Revision
    {
        public char Value { get; }

        public Revision(char value)
        {
            if (char.IsDigit(value) || char.IsLetter(value))
            {
                throw new EmptyOrNullRevisionException();
            }

            // if (value.Length != 1)
            // {
            //     throw new InvalidRevisionLengthException(value);
            // }

            Value = value;
        }

        public static implicit operator char(Revision revision) => revision.Value;
        public static implicit operator Revision(char revision) => new(revision);
    }
}
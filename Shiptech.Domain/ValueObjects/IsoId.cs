using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record IsoId
    {
        public string Value { get; }

        public IsoId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullIsoIdException();
            }

            if (value.Split("-").Length != 3)
            {
                throw new InvalidIsoIdFormatException(value);
            }

            Value = value;
        }

        public static implicit operator string(IsoId isoId) => isoId.Value;
        public static implicit operator IsoId(string isoId) => new(isoId);
    }
}
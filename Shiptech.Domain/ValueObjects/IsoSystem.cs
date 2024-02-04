using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record IsoSystem
    {
        public string Value { get; }

        public IsoSystem(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullIsoSystemException();
            }

            if (value.Split("-").Length != 1 || value.Split("-").Length != 2)
            {
                throw new InvalidIsoSystemFormatException(value);
            }

            Value = value;
        }

        public static implicit operator string(IsoSystem isoId) => isoId.Value;
        public static implicit operator IsoSystem(string isoId) => new(isoId);
    }
}
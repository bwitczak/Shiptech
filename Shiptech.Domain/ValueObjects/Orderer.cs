using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Orderer
    {
        public string Value { get; }

        public Orderer(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullOrdererException();
            }

            Value = value;
        }

        public static implicit operator string(Orderer orderer) => orderer.Value;
        public static implicit operator Orderer(string orderer) => new(orderer);
    }
}
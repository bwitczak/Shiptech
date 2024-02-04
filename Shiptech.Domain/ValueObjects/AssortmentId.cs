using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssortmentId
    {
        public string Value { get; }

        public AssortmentId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullAssortmentIdException();
            }

            Value = value;
        }

        public static implicit operator string(AssortmentId assortmentId) => assortmentId.Value;
        public static implicit operator AssortmentId(string assortmentId) => new(assortmentId);
    }
}
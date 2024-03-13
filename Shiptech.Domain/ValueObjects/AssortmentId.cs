using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssortmentId(string Value)
    {
        public static implicit operator string(AssortmentId assortmentId) => assortmentId.Value;
        public static implicit operator AssortmentId(string assortmentId) => new(assortmentId);
    }
}
namespace Shiptech.Domain.ValueObjects
{
    public record AssortmentName(string Value)
    {
        public static implicit operator string(AssortmentName assortmentName) => assortmentName.Value;
        public static implicit operator AssortmentName(string assortmentId) => new(assortmentId);
    }
}
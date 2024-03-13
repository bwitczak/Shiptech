using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssortmentStage(char? Value)
    {
        public static implicit operator char?(AssortmentStage assortmentStage) => assortmentStage.Value;
        public static implicit operator AssortmentStage(char? assortmentStage) => new(assortmentStage);
    }
}
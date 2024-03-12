using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssortmentStage
    {
        public char? Value { get; }

        public AssortmentStage(char? value)
        {
            // if (value is not null && !char.IsDigit(value))
            // {
            //     throw new InvalidAssortmentStageValueException(value);
            // }

            Value = value;
        }

        public static implicit operator char?(AssortmentStage assortmentStage) => assortmentStage.Value;
        public static implicit operator AssortmentStage(char? assortmentStage) => new(assortmentStage);
    }
}
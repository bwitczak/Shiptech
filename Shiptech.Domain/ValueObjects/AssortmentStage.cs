using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssortmentStage
    {
        public string? Value { get; }

        public AssortmentStage(string? value)
        {
            if (!value!.Equals("1") && !value!.Equals("2") && !value!.Equals("3"))
            {
                throw new InvalidAssortmentStageValueException(value);
            }

            Value = value;
        }

        public static implicit operator string?(AssortmentStage assortmentStage) => assortmentStage.Value;
        public static implicit operator AssortmentStage(string? assortmentStage) => new(assortmentStage);
    }
}
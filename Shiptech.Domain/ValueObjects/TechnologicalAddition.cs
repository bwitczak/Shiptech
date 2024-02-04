using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record TechnologicalAddition
    {
        public int? Value { get; }

        public TechnologicalAddition(int? value)
        {
            if (value is < 0)
            {
                throw new InvalidTechnologicalAdditionValueException(value);
            }

            Value = value;
        }

        public static implicit operator int?(TechnologicalAddition technologicalAddition) => technologicalAddition.Value;
        public static implicit operator TechnologicalAddition(int? technologicalAddition) => new(technologicalAddition);
    }
}
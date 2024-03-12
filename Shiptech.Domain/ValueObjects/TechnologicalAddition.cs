using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record TechnologicalAddition
    {
        public short? Value { get; }

        public TechnologicalAddition(short? value)
        {
            if (value is < 0)
            {
                throw new InvalidTechnologicalAdditionValueException(value);
            }

            Value = value;
        }

        public static implicit operator short?(TechnologicalAddition technologicalAddition) => technologicalAddition.Value;
        public static implicit operator TechnologicalAddition(short? technologicalAddition) => new(technologicalAddition);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record TechnologicalAddition(short? Value)
    {
        public static implicit operator short?(TechnologicalAddition technologicalAddition) => technologicalAddition.Value;
        public static implicit operator TechnologicalAddition(short? technologicalAddition) => new(technologicalAddition);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyWeight
    {
        public double Value { get; }

        public AssemblyWeight(double value)
        {
            if (value < 0)
            {
                throw new InvalidAssemblyWeightValueException(value);
            }

            Value = value;
        }

        public static implicit operator double(AssemblyWeight assemblyWeight) => assemblyWeight.Value;
        public static implicit operator AssemblyWeight(double assemblyWeight) => new(assemblyWeight);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyWeight(double Value)
    {
        public static implicit operator double(AssemblyWeight assemblyWeight) => assemblyWeight.Value;
        public static implicit operator AssemblyWeight(double assemblyWeight) => new(assemblyWeight);
    }
}
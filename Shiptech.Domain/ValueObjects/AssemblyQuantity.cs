using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyQuantity
    {
        public int Value { get; }

        public AssemblyQuantity(int value)
        {
            if (value < 0)
            {
                throw new InvalidAssemblyQuantityValueException(value);
            }

            Value = value;
        }

        public static implicit operator int(AssemblyQuantity assemblyQuantity) => assemblyQuantity.Value;
        public static implicit operator AssemblyQuantity(int assemblyQuantity) => new(assemblyQuantity);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyQuantity
    {
        public short Value { get; }

        public AssemblyQuantity(short value)
        {
            if (value < 0)
            {
                throw new InvalidAssemblyQuantityValueException(value);
            }

            Value = value;
        }

        public static implicit operator short(AssemblyQuantity assemblyQuantity) => assemblyQuantity.Value;
        public static implicit operator AssemblyQuantity(short assemblyQuantity) => new(assemblyQuantity);
    }
}
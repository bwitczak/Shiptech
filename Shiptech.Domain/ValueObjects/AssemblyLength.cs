using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyLength
    {
        public int Value { get; }

        public AssemblyLength(int value)
        {
            if (value < 0)
            {
                throw new InvalidAssemblyLengthValueException(value);
            }

            Value = value;
        }

        public static implicit operator int(AssemblyLength assemblyLength) => assemblyLength.Value;
        public static implicit operator AssemblyLength(int assemblyLength) => new(assemblyLength);
    }
}
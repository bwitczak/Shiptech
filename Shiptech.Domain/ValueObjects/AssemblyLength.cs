using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyLength
    {
        public short Value { get; }

        public AssemblyLength(short value)
        {
            if (value < 0)
            {
                throw new InvalidAssemblyLengthValueException(value);
            }

            Value = value;
        }

        public static implicit operator short(AssemblyLength assemblyLength) => assemblyLength.Value;
        public static implicit operator AssemblyLength(short assemblyLength) => new(assemblyLength);
    }
}
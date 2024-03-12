using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidAssemblyLengthValueException : ShiptechException
    {
        public InvalidAssemblyLengthValueException(short value) : base($"Invalid assembly length value: given {value}, required X > 0")
        {
        }
    }
}
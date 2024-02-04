using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidAssemblyQuantityValueException : ShiptechException
    {
        public InvalidAssemblyQuantityValueException(int value) : base($"Invalid assembly quantity value: given {value}, required X > 0")
        {
        }
    }
}
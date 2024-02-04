using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidAdditionValueException : ShiptechException
    {
        public InvalidAdditionValueException(int? value) : base($"Invalid addition: given {value}, required X > 0")
        {
        }
    }
}
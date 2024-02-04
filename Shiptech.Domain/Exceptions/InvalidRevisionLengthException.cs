using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidRevisionLengthException : ShiptechException
    {
        public InvalidRevisionLengthException(string value) : base($"Invalid revision length: given {value}, required 1 char")
        {
        }
    }
}
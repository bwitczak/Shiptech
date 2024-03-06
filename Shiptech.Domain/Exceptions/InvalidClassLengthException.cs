using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidClassLengthException : BaseException
    {
        public InvalidClassLengthException(string value) : base($"Invalid class length: given {value}, required 6 char")
        {
        }
    }
}
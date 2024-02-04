using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidPositionLengthException : ShiptechException
    {
        public InvalidPositionLengthException(string value) : base($"Invalid position length: given {value}, required 1 char")
        {
        }
    }
}
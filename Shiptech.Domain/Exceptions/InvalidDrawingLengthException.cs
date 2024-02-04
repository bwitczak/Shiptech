using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidDrawingLengthException : ShiptechException
    {
        public InvalidDrawingLengthException(int? value) : base($"Invalid drawing length: given {value}, required X > 0")
        {
        }
    }
}
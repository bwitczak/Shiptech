using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidDrawingIdFormatException : ShiptechException
    {
        public InvalidDrawingIdFormatException(string value) : base($"Invalid drawing ID format: given {value}, required XXX-XXX")
        {
        }
    }
}
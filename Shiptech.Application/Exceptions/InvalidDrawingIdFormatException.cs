using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidDrawingIdFormatException : ShiptechException
    {
        internal InvalidDrawingIdFormatException(string value) : base($"Invalid drawing ID format: given {value}, required XXX-XXX")
        {
        }
    }
}
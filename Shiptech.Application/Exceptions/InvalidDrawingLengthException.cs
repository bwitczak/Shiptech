using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidDrawingLengthException : ShiptechException
    {
        internal InvalidDrawingLengthException(short? value) : base($"Invalid drawing length: given {value}, required X > 0")
        {
        }
    }
}
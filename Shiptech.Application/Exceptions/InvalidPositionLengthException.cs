using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPositionLengthException : ShiptechException
    {
        internal InvalidPositionLengthException(char value) : base($"Invalid position length: given {value}, required 1 char")
        {
        }
    }
}
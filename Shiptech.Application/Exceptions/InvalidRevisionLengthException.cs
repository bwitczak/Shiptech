using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidRevisionLengthException : ShiptechException
    {
        internal InvalidRevisionLengthException(char value) : base($"Invalid revision length: given {value}, required 1 char")
        {
        }
    }
}
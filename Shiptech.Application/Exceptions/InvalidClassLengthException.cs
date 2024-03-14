using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidClassLengthException : ShiptechException
    {
        internal InvalidClassLengthException(string value) : base($"Invalid class length: given {value}, required 6 char")
        {
        }
    }
}
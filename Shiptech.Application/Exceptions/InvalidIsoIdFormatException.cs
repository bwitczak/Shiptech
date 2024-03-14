using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidIsoIdFormatException : ShiptechException
    {
        internal InvalidIsoIdFormatException(string value) : base($"Invalid iso ID format: given {value}, required XXX-XXX-XXX")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidIsoSystemFormatException : ShiptechException
    {
        internal InvalidIsoSystemFormatException(string value) : base($"Invalid iso system format: given {value}, required XXX or XXX-XXX")
        {
        }
    }
}
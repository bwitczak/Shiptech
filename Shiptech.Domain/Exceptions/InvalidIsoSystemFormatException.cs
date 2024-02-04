using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidIsoSystemFormatException : ShiptechException
    {
        public InvalidIsoSystemFormatException(string value) : base($"Invalid iso system format: given {value}, required XXX or XXX-XXX")
        {
        }
    }
}
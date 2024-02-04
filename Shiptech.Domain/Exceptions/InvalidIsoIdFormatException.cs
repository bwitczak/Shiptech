using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidIsoIdFormatException : ShiptechException
    {
        public InvalidIsoIdFormatException(string value) : base($"Invalid iso ID format: given {value}, required XXX-XXX-XXX")
        {
        }
    }
}
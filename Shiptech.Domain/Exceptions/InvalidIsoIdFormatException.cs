using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidIsoIdFormatException : BaseException
    {
        public InvalidIsoIdFormatException(string value) : base($"Invalid iso ID format: given {value}, required XXX-XXX-XXX")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidSectionValueException : ShiptechException
    {
        public InvalidSectionValueException(string value) : base(
            $"Invalid section value: given {value}, required X > 0")
        {
        }
    }
}
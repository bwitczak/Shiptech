using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidSectionValueException : BaseException
    {
        public InvalidSectionValueException(string value) : base(
            $"Invalid section value: given {value}, required X > 0")
        {
        }
    }
}
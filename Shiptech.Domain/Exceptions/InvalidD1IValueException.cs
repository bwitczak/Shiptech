using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidD1IValueException : ShiptechException
    {
        public InvalidD1IValueException(short? value) : base(
            $"Invalid D1I value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
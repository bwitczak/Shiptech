using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidD15IValueException : ShiptechException
    {
        public InvalidD15IValueException(int? value) : base(
            $"Invalid D15I value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
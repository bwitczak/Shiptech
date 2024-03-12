using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidD1IIValueException : ShiptechException
    {
        public InvalidD1IIValueException(short? value) : base(
            $"Invalid D1II value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
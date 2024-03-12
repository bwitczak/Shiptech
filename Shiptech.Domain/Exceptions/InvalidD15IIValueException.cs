using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidD15IIValueException : ShiptechException
    {
        public InvalidD15IIValueException(short? value) : base(
            $"Invalid D15II value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal class InvalidD15IValueException : ShiptechException
    {
        internal InvalidD15IValueException(short? value) : base(
            $"Invalid D15I value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
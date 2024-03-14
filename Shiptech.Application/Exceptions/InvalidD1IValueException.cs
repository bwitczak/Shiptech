using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD1IValueException : ShiptechException
    {
        internal InvalidD1IValueException(short? value) : base(
            $"Invalid D1I value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
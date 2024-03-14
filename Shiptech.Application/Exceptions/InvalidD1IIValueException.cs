using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD1IIValueException : ShiptechException
    {
        internal InvalidD1IIValueException(short? value) : base(
            $"Invalid D1II value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
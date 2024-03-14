using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD15IIValueException : ShiptechException
    {
        internal InvalidD15IIValueException(short? value) : base(
            $"Invalid D15II value: given {value}, required X > 0 and X < 90")
        {
        }
    }
}
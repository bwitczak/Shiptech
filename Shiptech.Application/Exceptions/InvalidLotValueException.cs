using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidLotValueException : ShiptechException
    {
        internal InvalidLotValueException(string value) : base(
            $"Invalid lot value: given {value}, required X > 99 and X < 1000")
        {
        }
    }
}
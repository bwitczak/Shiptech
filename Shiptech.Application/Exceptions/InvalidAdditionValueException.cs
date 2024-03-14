using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAdditionValueException : ShiptechException
    {
        internal InvalidAdditionValueException(short? value) : base($"Invalid addition: given {value}, required X > 0")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAtestValueException : ShiptechException
    {
        internal InvalidAtestValueException(string value) : base(
            $"Invalid atest value: given {value}, required one of (NONE, NO, YES)")
        {
        }
    }
}
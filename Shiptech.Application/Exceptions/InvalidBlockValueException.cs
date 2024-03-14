using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidBlockValueException : ShiptechException
    {
        internal InvalidBlockValueException(string value) : base(
            $"Invalid block value: given {value}, required X > 99 and X < 1000")
        {
        }
    }
}
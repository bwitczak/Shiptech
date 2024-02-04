using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidBlockValueException : ShiptechException
    {
        public InvalidBlockValueException(string value) : base(
            $"Invalid block value: given {value}, required X > 99 and X < 1000")
        {
        }
    }
}
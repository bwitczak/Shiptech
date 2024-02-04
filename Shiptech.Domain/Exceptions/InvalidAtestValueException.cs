using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidAtestValueException : ShiptechException
    {
        public InvalidAtestValueException(AtestEnum value) : base(
            $"Invalid atest value: given {value}, required one of (NONE, NO, YES)")
        {
        }
    }
}
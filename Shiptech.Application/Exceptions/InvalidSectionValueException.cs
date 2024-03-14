using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidSectionValueException : ShiptechException
    {
        internal InvalidSectionValueException(string value) : base(
            $"Invalid section value: given {value}, required X > 0")
        {
        }
    }
}
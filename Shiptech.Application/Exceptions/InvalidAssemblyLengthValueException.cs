using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssemblyLengthValueException : ShiptechException
    {
        internal InvalidAssemblyLengthValueException(short value) : base($"Invalid assembly length value: given {value}, required X > 0")
        {
        }
    }
}
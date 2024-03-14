using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssemblyQuantityValueException : ShiptechException
    {
        internal InvalidAssemblyQuantityValueException(short value) : base($"Invalid assembly quantity value: given {value}, required X > 0")
        {
        }
    }
}
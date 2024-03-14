using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPrefabricationQuantityValueException : ShiptechException
    {
        internal InvalidPrefabricationQuantityValueException(short value) : base($"Invalid prefabrication quantity value: given {value}, required X > 0")
        {
        }
    }
}
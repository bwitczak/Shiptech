using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPrefabricationLengthValueException : ShiptechException
    {
        internal InvalidPrefabricationLengthValueException(short value) : base($"Invalid prefabrication length value: given {value}, required X > 0")
        {
        }
    }
}
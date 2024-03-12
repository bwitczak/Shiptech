using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidPrefabricationQuantityValueException : ShiptechException
    {
        public InvalidPrefabricationQuantityValueException(short value) : base($"Invalid prefabrication quantity value: given {value}, required X > 0")
        {
        }
    }
}
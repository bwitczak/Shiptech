using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidPrefabricationLengthValueException : ShiptechException
    {
        public InvalidPrefabricationLengthValueException(short value) : base($"Invalid prefabrication length value: given {value}, required X > 0")
        {
        }
    }
}
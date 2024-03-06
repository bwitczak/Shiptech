using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidPrefabricationQuantityValueException : BaseException
    {
        public InvalidPrefabricationQuantityValueException(int value) : base($"Invalid prefabrication quantity value: given {value}, required X > 0")
        {
        }
    }
}
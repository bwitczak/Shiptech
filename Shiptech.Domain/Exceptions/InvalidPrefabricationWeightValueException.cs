using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidPrefabricationWeightValueException : ShiptechException
    {
        public InvalidPrefabricationWeightValueException(double value) : base($"Invalid prefabrication weight value: given {value}, required X > 0")
        {
        }
    }
}
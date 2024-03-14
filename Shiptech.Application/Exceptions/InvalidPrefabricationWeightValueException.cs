using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPrefabricationWeightValueException : ShiptechException
    {
        internal InvalidPrefabricationWeightValueException(double value) : base($"Invalid prefabrication weight value: given {value}, required X > 0")
        {
        }
    }
}
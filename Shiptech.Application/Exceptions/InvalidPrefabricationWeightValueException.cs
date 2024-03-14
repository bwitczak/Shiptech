using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPrefabricationWeightValueException : ValidationFailure
    {
        internal InvalidPrefabricationWeightValueException(double prefabricationWeight) : base(nameof(prefabricationWeight),$"Waga prefabrykacji {prefabricationWeight}kg jest < 0!")
        {
        }
    }
}
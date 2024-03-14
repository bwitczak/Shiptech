using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPrefabricationQuantityValueException : ValidationFailure
    {
        internal InvalidPrefabricationQuantityValueException(short prefabricationQuantity) : base(nameof(prefabricationQuantity),$"Ilość prefabrykacji {prefabricationQuantity} jest < 0!")
        {
        }
    }
}
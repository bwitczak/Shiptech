using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPrefabricationLengthValueException : ValidationFailure
    {
        internal InvalidPrefabricationLengthValueException(short prefabricationLength) : base(nameof(prefabricationLength),$"Długość prefabrykacji {prefabricationLength}mm jest < 0!")
        {
        }
    }
}
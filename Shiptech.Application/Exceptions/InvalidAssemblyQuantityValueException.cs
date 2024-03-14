using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssemblyQuantityValueException : ValidationFailure
    {
        internal InvalidAssemblyQuantityValueException(short assemblyQuantity) : base(nameof(assemblyQuantity),$"Ilość montażowa {assemblyQuantity} jest < 0!")
        {
        }
    }
}
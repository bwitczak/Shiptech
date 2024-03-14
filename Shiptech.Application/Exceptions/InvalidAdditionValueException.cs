using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAdditionValueException : ValidationFailure
    {
        internal InvalidAdditionValueException(short? addition) : base(nameof(addition),$"Naddatek {addition}mm jest < 0!")
        {
        }
    }
}
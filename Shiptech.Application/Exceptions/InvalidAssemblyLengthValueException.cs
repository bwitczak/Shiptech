using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssemblyLengthValueException : ValidationFailure
    {
        internal InvalidAssemblyLengthValueException(short assemblyLength) : base(nameof(assemblyLength),$"Długość montażu {assemblyLength}mm jest < 0!")
        {
        }
    }
}
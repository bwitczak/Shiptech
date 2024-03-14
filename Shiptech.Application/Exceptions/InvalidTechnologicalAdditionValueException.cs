using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidTechnologicalAdditionValueException : ValidationFailure
    {
        internal InvalidTechnologicalAdditionValueException(short? technologicalAddition) : base(nameof(technologicalAddition), $"Długość technologicznego naddatku {technologicalAddition}mm jest < 0!")
        {
        }
    }
}
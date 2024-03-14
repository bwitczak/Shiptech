using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssemblyWeightValueException : ValidationFailure
    {
        internal InvalidAssemblyWeightValueException(double assemblyWeight) : base(nameof(assemblyWeight),$"Waga montażowa {assemblyWeight}kg jest < 0!")
        {
        }
    }
}
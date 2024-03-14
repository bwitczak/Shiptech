using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class EmptyOrNullChemicalProcessNameException : ValidationFailure
{
    internal EmptyOrNullChemicalProcessNameException() : base("chemicalProcessName",$"Nazwa procesu chemicznego nie może być pusta!")
    {
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class EmptyOrNullChemicalProcessIdException : ValidationFailure
{
    internal EmptyOrNullChemicalProcessIdException() : base("id",$"Nazwa procesu chemicznego nie może być pusta!")
    {
    }
}
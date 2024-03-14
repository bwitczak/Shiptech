using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullIsoIdException : ValidationFailure
    {
        internal EmptyOrNullIsoIdException() : base("id",$"Nazwa izometryka nie może być pusta!")
        {
        }
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullAssortmentIdException : ValidationFailure
    {
        internal EmptyOrNullAssortmentIdException() : base("id",$"Nazwa asortymentu nie może być pusta!")
        {
        }
    }
}
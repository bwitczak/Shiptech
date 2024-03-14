using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullPositionException : ValidationFailure
    {
        internal EmptyOrNullPositionException() : base("position",$"Nazwa pozycji nie może być pusta!")
        {
        }
    }
}
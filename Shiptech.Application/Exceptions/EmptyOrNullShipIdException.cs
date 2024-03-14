using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullShipIdException : ValidationFailure
    {
        internal EmptyOrNullShipIdException() : base("id",$"Nazwa statku nie może być pusta!")
        {
        }
    }
}
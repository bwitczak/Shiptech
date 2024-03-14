using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullRevisionException : ValidationFailure
    {
        internal EmptyOrNullRevisionException() : base("revision",$"Nazwa rewizji nie może być pusta!")
        {
        }
    }
}
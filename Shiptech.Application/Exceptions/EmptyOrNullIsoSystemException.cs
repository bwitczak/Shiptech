using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullIsoSystemException : ValidationFailure
    {
        internal EmptyOrNullIsoSystemException() : base("system",$"Nazwa systemu nie może być pusta!")
        {
        }
    }
}
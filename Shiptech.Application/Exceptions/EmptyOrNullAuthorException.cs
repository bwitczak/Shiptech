using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullAuthorException : ValidationFailure
    {
        internal EmptyOrNullAuthorException() : base("author",$"Autor nie może być pusty!")
        {
        }
    }
}
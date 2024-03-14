using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullClassException : ValidationFailure
    {
        internal EmptyOrNullClassException() : base("class",$"Nazwa klasy nie może być pusta!")
        {
        }
    }
}
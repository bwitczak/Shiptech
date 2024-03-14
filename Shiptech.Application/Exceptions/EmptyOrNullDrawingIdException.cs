using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullDrawingIdException : ValidationFailure
    {
        internal EmptyOrNullDrawingIdException() : base("id",$"Nazwa rysunku nie może być pusta!")
        {
        }
    }
}
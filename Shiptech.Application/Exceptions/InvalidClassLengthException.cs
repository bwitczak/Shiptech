using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidClassLengthException : ValidationFailure
    {
        internal InvalidClassLengthException(string @class) : base("class",$"Nie poprawna klasa {@class}! Wymagane 6 znaków")
        {
        }
    }
}
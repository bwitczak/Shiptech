using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAtestValueException : ValidationFailure
    {
        internal InvalidAtestValueException(string atest) : base(nameof(atest),$"Nie poprawny atest {atest}! Wymagane Tak/Nie/Puste")
        {
        }
    }
}
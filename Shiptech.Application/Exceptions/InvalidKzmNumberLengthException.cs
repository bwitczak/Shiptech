using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidKzmNumberLengthException : ValidationFailure
    {
        internal InvalidKzmNumberLengthException(string kzmNumber) : base(nameof(kzmNumber),$"Niepoprawny format numeru KZM {kzmNumber}! Wymagane 6 znaków")
        {
        }
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD1IValueException : ValidationFailure
    {
        internal InvalidD1IValueException(short? d1I) : base(nameof(d1I),$"Niepoprawny kąt 1D {d1I}! Wymagane > 0 oraz <= 90")
        {
        }
    }
}
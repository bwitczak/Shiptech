using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD15IValueException : ValidationFailure
    {
        internal InvalidD15IValueException(short? d15I) : base(nameof(d15I),$"Niepoprawny kąt 1.5D {d15I}! Wymagane > 0 oraz <= 90")
        {
        }
    }
}
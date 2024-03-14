using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD1IIValueException : ValidationFailure
    {
        internal InvalidD1IIValueException(short? d1II) : base(nameof(d1II),$"Niepoprawny kąt 1D {d1II}! Wymagane > 0 oraz <= 90")
        {
        }
    }
}
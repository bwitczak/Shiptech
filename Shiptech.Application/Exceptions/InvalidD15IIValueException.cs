using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidD15IIValueException : ValidationFailure
    {
        internal InvalidD15IIValueException(short? d15II) : base(nameof(d15II),$"Niepoprawny kąt 1.5D {d15II}! Wymagane > 0 oraz <= 90")
        {
        }
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidLotValueException : ValidationFailure
    {
        internal InvalidLotValueException(string lot) : base(nameof(lot),$"Niepoprawny lot {lot}! Wymagane > 99 oraz < 1000")
        {
        }
    }
}
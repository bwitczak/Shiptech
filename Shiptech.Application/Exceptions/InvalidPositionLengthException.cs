using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidPositionLengthException : ValidationFailure
    {
        internal InvalidPositionLengthException(char position) : base(nameof(position),$"Niepoprawna pozycja {position}! Wymagany 1 znak")
        {
        }
    }
}
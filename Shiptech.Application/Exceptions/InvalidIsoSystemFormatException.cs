using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidIsoSystemFormatException : ValidationFailure
    {
        internal InvalidIsoSystemFormatException(string system) : base(nameof(system),$"Niepoprawny format systemu izometryka {system}! Wymagany format XXX lub XXX-XXX")
        {
        }
    }
}
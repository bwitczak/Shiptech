using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidIsoIdFormatException : ValidationFailure
    {
        internal InvalidIsoIdFormatException(string id) : base(nameof(id),$"Niepoprawny format nazwy izometryka {id}! Wymagany format XXX-XXX-XXX")
        {
        }
    }
}
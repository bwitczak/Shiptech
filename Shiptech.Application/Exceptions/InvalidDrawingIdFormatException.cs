using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidDrawingIdFormatException : ValidationFailure
    {
        internal InvalidDrawingIdFormatException(string id) : base(nameof(id),$"Niepoprawny format nazwy rysunku {id}! Wymagany format XXX-XXX")
        {
        }
    }
}
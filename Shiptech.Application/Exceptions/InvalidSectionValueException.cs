using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidSectionValueException : ValidationFailure
    {
        internal InvalidSectionValueException(string section) : base(nameof(section),$"Niepoprawna sekcja {section}! Wymagane > 0")
        {
        }
    }
}
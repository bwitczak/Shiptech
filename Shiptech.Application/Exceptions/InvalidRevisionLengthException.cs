using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidRevisionLengthException : ValidationFailure
    {
        internal InvalidRevisionLengthException(char revision) : base(nameof(revision),$"Niepoprawna rewizja {revision}! Wymagany 1 znak")
        {
        }
    }
}
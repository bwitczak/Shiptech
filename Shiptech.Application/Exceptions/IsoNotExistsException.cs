using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class IsoNotExistsException : ValidationFailure
{
    internal IsoNotExistsException(string id) : base(nameof(id), $"{id} nie istnieje w bazie!")
    {
    }
}
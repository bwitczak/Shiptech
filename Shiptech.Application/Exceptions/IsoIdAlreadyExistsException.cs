using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class IsoIdAlreadyExistsException : ValidationFailure
{
    internal IsoIdAlreadyExistsException(string id) : base(nameof(id), $"{id} już istnieje w bazie!")
    {
    }
}
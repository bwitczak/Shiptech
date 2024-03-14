using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class DrawingIdAlreadyExistsException : ValidationFailure
{
    internal DrawingIdAlreadyExistsException(string id) : base(nameof(id),$"{id} istnieje w bazie!")
    {
    }
}
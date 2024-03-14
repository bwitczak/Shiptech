using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class DrawingIdNotExistsException : ValidationFailure
{
    internal DrawingIdNotExistsException(string id) : base(nameof(id),$"{id} nie istnieje w bazie!")
    {
    }
}
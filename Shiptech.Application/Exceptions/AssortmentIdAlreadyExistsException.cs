using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class AssortmentIdAlreadyExistsException : ValidationFailure
{
    internal AssortmentIdAlreadyExistsException(string id) : base(nameof(id),$"{id} już istnieje w bazie!")
    {
    }
}
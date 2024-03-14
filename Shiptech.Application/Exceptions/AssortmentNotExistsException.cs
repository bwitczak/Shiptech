using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class AssortmentNotExistsException : ValidationFailure
{
    internal AssortmentNotExistsException(string id) : base(nameof(id),$"{id} nie istnieje w bazie!")
    {
    }
}
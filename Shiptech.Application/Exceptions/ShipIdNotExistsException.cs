using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class ShipIdNotExistsException : ValidationFailure
{
    internal ShipIdNotExistsException(string id) : base(nameof(id), $"{id} nie istnieje w bazie!")
    {
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class ShipOrdererAlreadyExistsException : ValidationFailure
{
    internal ShipOrdererAlreadyExistsException(string orderer) : base(nameof(orderer), $"{orderer} już istnieje w bazie!")
    {
    }
}
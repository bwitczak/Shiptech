using FluentValidation.Results;
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class ShipOrdererAlreadyExistsException : ValidationFailure
{
    internal ShipOrdererAlreadyExistsException(string orderer) : base(nameof(orderer), $"Already exists: given {orderer} exists in database")
    {
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ShipOrdererAlreadyExistsException : ShiptechException
{
    public ShipOrdererAlreadyExistsException(string orderer) : base($"Already exists: given {orderer} exists in database")
    {
    }
}
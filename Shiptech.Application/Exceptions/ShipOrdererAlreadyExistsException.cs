using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ShipOrdererAlreadyExistsException : ConflictException
{
    public ShipOrdererAlreadyExistsException(string field, string value) : base(field,value)
    {
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ShipNotExistsException : ShiptechException
{
    public ShipNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
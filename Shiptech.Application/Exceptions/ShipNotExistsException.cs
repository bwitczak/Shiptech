using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class ShipNotExistsException : ShiptechException
{
    internal ShipNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
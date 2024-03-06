using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ShipNotExistsException : NotFoundException
{
    public ShipNotExistsException(string id) : base(id)
    {
    }
}
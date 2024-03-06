using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class IsoNotExistsException : NotFoundException
{
    public IsoNotExistsException(string id) : base(id)
    {
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class IsoAlreadyExistsException : ConflictException
{
    public IsoAlreadyExistsException(string id) : base(id)
    {
    }
}
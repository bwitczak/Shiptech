using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class IsoNotExistsException : ShiptechException
{
    public IsoNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
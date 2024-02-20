using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class IsoIdAlreadyExistsException : ShiptechException
{
    public IsoIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
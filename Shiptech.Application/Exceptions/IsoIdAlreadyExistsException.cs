using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class IsoIdAlreadyExistsException : ShiptechException
{
    internal IsoIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
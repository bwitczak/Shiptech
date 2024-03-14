using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class IsoNotExistsException : ShiptechException
{
    internal IsoNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class AssortmentIdAlreadyExistsException : ShiptechException
{
    internal AssortmentIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
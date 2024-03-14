using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class AssortmentNotExistsException : ShiptechException
{
    internal AssortmentNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
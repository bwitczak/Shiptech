using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class DrawingNotExistsException : ShiptechException
{
    internal DrawingNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
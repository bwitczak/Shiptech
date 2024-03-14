using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class DrawingIdAlreadyExistsException : ShiptechException
{
    internal DrawingIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
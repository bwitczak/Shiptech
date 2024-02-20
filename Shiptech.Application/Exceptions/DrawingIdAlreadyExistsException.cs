using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class DrawingIdAlreadyExistsException : ShiptechException
{
    public DrawingIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
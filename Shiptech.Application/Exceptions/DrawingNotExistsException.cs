using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class DrawingNotExistsException : ShiptechException
{
    public DrawingNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
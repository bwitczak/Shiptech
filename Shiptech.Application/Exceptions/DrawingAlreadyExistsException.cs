using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class DrawingAlreadyExistsException : ConflictException
{
    public DrawingAlreadyExistsException(string id) : base(id)
    {
    }
}
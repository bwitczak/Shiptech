using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class DrawingNotExistsException : NotFoundException
{
    public DrawingNotExistsException(string id) : base(id)
    {
    }
}
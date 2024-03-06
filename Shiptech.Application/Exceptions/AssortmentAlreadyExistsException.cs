using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class AssortmentAlreadyExistsException : ConflictException
{
    public AssortmentAlreadyExistsException(string id) : base(id)
    {
    }
}
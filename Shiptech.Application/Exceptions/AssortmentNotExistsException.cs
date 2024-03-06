using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class AssortmentNotExistsException : NotFoundException
{
    public AssortmentNotExistsException(string id) : base(id)
    {
    }
}
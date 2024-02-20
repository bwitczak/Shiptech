using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class AssortmentNotExistsException : ShiptechException
{
    public AssortmentNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
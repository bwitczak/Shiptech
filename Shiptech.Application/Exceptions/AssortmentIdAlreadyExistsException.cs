using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class AssortmentIdAlreadyExistsException : ShiptechException
{
    public AssortmentIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
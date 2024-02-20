using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ChemicalProcessIdAlreadyExistsException : ShiptechException
{
    public ChemicalProcessIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
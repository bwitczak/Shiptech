using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ChemicalProcessNotExistsException : ShiptechException
{
    public ChemicalProcessNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
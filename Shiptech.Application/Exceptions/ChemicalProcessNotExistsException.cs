using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal class ChemicalProcessNotExistsException : ShiptechException
{
    internal ChemicalProcessNotExistsException(string id) : base($"Not found: given {id} not exists in database")
    {
    }
}
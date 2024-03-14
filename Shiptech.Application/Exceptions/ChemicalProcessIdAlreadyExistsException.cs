using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class ChemicalProcessIdAlreadyExistsException : ShiptechException
{
    internal ChemicalProcessIdAlreadyExistsException(string id) : base($"Already exists: given {id} exists in database")
    {
    }
}
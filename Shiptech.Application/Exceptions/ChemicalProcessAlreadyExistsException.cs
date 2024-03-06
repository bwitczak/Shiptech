using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ChemicalProcessAlreadyExistsException : ConflictException
{
    public ChemicalProcessAlreadyExistsException(string id) : base(id)
    {
    }
}
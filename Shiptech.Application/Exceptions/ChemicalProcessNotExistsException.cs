using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

public class ChemicalProcessNotExistsException : NotFoundException
{
    public ChemicalProcessNotExistsException(string id) : base(id)
    {
    }
}
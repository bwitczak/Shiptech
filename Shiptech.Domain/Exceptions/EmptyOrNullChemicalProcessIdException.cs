using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions;

public class EmptyOrNullChemicalProcessIdException : BaseException
{
    public EmptyOrNullChemicalProcessIdException() : base("Chemical process ID cannot be empty and null")
    {
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions;

public class EmptyOrNullChemicalProcessIdException : ShiptechException
{
    public EmptyOrNullChemicalProcessIdException() : base("Chemical process ID cannot be empty and null")
    {
    }
}
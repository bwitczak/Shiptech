using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions;

public class EmptyOrNullChemicalProcessNameException : BaseException
{
    public EmptyOrNullChemicalProcessNameException() : base("Chemical process name cannot be empty and null")
    {
    }
}
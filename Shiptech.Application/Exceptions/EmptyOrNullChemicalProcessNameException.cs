using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class EmptyOrNullChemicalProcessNameException : ShiptechException
{
    internal EmptyOrNullChemicalProcessNameException() : base("Chemical process name cannot be empty and null")
    {
    }
}
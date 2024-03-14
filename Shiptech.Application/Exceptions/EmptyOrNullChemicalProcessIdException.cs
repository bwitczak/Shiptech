using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions;

internal sealed class EmptyOrNullChemicalProcessIdException : ShiptechException
{
    internal EmptyOrNullChemicalProcessIdException() : base("Chemical process ID cannot be empty and null")
    {
    }
}
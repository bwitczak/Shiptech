using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssortmentStageValueException : ShiptechException
    {
        internal InvalidAssortmentStageValueException(char? value) : base($"Invalid AssortmentStage: given {value}, required 1, 2 or 3")
        {
        }
    }
}
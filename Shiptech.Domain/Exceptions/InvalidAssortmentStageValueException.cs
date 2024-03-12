using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidAssortmentStageValueException : ShiptechException
    {
        public InvalidAssortmentStageValueException(char? value) : base($"Invalid AssortmentStage: given {value}, required 1, 2 or 3")
        {
        }
    }
}
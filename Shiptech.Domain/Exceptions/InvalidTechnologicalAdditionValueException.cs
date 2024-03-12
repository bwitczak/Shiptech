using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidTechnologicalAdditionValueException : ShiptechException
    {
        public InvalidTechnologicalAdditionValueException(short? value) : base($"Invalid technological addition: given {value}, required X > 0")
        {
        }
    }
}
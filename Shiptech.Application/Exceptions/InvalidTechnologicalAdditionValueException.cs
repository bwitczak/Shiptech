using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidTechnologicalAdditionValueException : ShiptechException
    {
        internal InvalidTechnologicalAdditionValueException(short? value) : base($"Invalid technological addition: given {value}, required X > 0")
        {
        }
    }
}
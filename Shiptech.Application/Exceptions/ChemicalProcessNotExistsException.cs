using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class ChemicalProcessNotExistsException : ValidationFailure
{
    internal ChemicalProcessNotExistsException(string id) : base(nameof(id),$"{id} nie istnieje w bazie!")
    {
    }
}
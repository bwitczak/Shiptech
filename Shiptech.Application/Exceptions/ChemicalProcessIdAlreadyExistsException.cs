using FluentValidation.Results;

namespace Shiptech.Application.Exceptions;

internal sealed class ChemicalProcessIdAlreadyExistsException : ValidationFailure
{
    internal ChemicalProcessIdAlreadyExistsException(string id) : base(nameof(id), $"{id} już istnieje w bazie!")
    {
    }
}
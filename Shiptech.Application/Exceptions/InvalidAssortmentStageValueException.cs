using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssortmentStageValueException : ValidationFailure
    {
        internal InvalidAssortmentStageValueException(char? assortmentStage) : base(nameof(assortmentStage),$"Niepoprawna faza {assortmentStage}! Wymagane 1, 2 or 3")
        {
        }
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidStageValueException : ValidationFailure
    {
        internal InvalidStageValueException(string stage) : base(nameof(stage),$"Niepoprawna sekcja {stage}! Wymagane ODP/ODS/ODI/Puste")
        {
        }
    }
}
using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidBlockValueException : ValidationFailure
    {
        internal InvalidBlockValueException(string block) : base(nameof(block),$"Nie poprawny blok {block}! Wymagane > 99 oraz < 1000")
        {
        }
    }
}
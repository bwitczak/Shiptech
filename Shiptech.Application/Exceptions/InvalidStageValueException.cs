using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidStageValueException : ShiptechException
    {
        internal InvalidStageValueException(string value) : base(
            $"Invalid stage value: given {value}, required one of (NONE, ODP, ODS, ODI)")
        {
        }
    }
}
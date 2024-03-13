using Shiptech.Domain.Consts;
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidStageValueException : ShiptechException
    {
        public InvalidStageValueException(string value) : base(
            $"Invalid stage value: given {value}, required one of (NONE, ODP, ODS, ODI)")
        {
        }
    }
}
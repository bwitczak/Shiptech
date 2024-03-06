using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidLotValueException : BaseException
    {
        public InvalidLotValueException(string value) : base(
            $"Invalid lot value: given {value}, required X > 99 and X < 1000")
        {
        }
    }
}
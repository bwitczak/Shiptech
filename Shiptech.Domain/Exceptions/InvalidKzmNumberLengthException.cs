using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidKzmNumberLengthException : BaseException
    {
        public InvalidKzmNumberLengthException(string value) : base(
            $"Invalid Kzm number length: given {value}, required X = 6 chars")
        {
        }
    }
}
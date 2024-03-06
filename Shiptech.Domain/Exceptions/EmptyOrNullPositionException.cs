using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullPositionException : BaseException
    {
        public EmptyOrNullPositionException() : base("Position cannot be empty and null")
        {
        }
    }
}
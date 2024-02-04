using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullPositionException : ShiptechException
    {
        public EmptyOrNullPositionException() : base("Position cannot be empty and null")
        {
        }
    }
}
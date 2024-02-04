using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullShipIdException : ShiptechException
    {
        public EmptyOrNullShipIdException() : base("Ship ID cannot be empty and null")
        {
        }
    }
}
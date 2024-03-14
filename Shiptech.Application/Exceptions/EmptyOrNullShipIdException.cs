using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullShipIdException : ShiptechException
    {
        internal EmptyOrNullShipIdException() : base("Ship ID cannot be empty and null")
        {
        }
    }
}
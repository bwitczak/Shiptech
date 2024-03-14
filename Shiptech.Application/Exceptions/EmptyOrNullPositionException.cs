using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullPositionException : ShiptechException
    {
        internal EmptyOrNullPositionException() : base("Position cannot be empty and null")
        {
        }
    }
}
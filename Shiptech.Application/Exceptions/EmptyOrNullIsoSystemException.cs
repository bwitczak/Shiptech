using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullIsoSystemException : ShiptechException
    {
        internal EmptyOrNullIsoSystemException() : base("Iso system cannot be empty and null")
        {
        }
    }
}
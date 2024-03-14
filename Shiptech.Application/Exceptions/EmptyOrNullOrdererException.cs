using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullOrdererException : ShiptechException
    {
        internal EmptyOrNullOrdererException() : base("Orderer cannot be empty and null")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullRevisionException : ShiptechException
    {
        internal EmptyOrNullRevisionException() : base("Revision cannot be empty and null")
        {
        }
    }
}
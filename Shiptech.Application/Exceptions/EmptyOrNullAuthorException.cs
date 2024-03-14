using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullAuthorException : ShiptechException
    {
        internal EmptyOrNullAuthorException() : base("Author cannot be empty and null")
        {
        }
    }
}
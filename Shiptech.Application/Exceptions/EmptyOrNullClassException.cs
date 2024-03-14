using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullClassException : ShiptechException
    {
        internal EmptyOrNullClassException() : base("Class cannot be empty and null")
        {
        }
    }
}
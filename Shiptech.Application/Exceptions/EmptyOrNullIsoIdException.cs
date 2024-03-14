using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullIsoIdException : ShiptechException
    {
        internal EmptyOrNullIsoIdException() : base("Iso ID cannot be empty and null")
        {
        }
    }
}
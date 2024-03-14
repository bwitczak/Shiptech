using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullDrawingIdException : ShiptechException
    {
        internal EmptyOrNullDrawingIdException() : base("Drawing ID cannot be empty and null")
        {
        }
    }
}
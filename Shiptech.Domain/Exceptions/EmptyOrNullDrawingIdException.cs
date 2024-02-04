using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullDrawingIdException : ShiptechException
    {
        public EmptyOrNullDrawingIdException() : base("Drawing ID cannot be empty and null")
        {
        }
    }
}
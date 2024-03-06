using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullDrawingIdException : BaseException
    {
        public EmptyOrNullDrawingIdException() : base("Drawing ID cannot be empty and null")
        {
        }
    }
}
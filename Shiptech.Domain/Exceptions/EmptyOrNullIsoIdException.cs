using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullIsoIdException : ShiptechException
    {
        public EmptyOrNullIsoIdException() : base("Iso ID cannot be empty and null")
        {
        }
    }
}
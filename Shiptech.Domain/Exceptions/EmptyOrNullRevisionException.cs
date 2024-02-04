using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullRevisionException : ShiptechException
    {
        public EmptyOrNullRevisionException() : base("Revision cannot be empty and null")
        {
        }
    }
}
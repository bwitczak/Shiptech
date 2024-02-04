using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullIsoSystemException : ShiptechException
    {
        public EmptyOrNullIsoSystemException() : base("Iso system cannot be empty and null")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullClassException : ShiptechException
    {
        public EmptyOrNullClassException() : base("Class cannot be empty and null")
        {
        }
    }
}
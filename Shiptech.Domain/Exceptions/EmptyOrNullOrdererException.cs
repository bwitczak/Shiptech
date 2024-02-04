using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullOrdererException : ShiptechException
    {
        public EmptyOrNullOrdererException() : base("Orderer cannot be empty and null")
        {
        }
    }
}
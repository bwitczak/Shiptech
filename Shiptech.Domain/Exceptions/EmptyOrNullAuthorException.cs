using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullAuthorException : BaseException
    {
        public EmptyOrNullAuthorException() : base("Author cannot be empty and null")
        {
        }
    }
}
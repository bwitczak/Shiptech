using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullAssortmentIdException : BaseException
    {
        public EmptyOrNullAssortmentIdException() : base("Assortment ID cannot be empty and null")
        {
        }
    }
}
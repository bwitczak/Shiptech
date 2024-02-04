using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class EmptyOrNullAssortmentIdException : ShiptechException
    {
        public EmptyOrNullAssortmentIdException() : base("Assortment ID cannot be empty and null")
        {
        }
    }
}
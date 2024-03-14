using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullAssortmentIdException : ShiptechException
    {
        internal EmptyOrNullAssortmentIdException() : base("Assortment ID cannot be empty and null")
        {
        }
    }
}
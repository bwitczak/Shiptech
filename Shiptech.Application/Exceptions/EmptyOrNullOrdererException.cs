using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class EmptyOrNullOrdererException : ValidationFailure
    {
        internal EmptyOrNullOrdererException() : base("orderer",$"Nazwa zamawiającego nie może być pusta!")
        {
        }
    }
}
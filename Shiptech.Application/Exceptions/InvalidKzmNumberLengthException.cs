using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidKzmNumberLengthException : ShiptechException
    {
        internal InvalidKzmNumberLengthException(string value) : base(
            $"Invalid Kzm number length: given {value}, required X = 6 chars")
        {
        }
    }
}
using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidAssemblyWeightValueException : ShiptechException
    {
        internal InvalidAssemblyWeightValueException(double value) : base($"Invalid assembly weight value: given {value}, required X > 0")
        {
        }
    }
}
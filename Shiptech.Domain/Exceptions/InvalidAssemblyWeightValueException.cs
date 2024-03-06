using Shiptech.Shared.Abstractions.Exceptions;

namespace Shiptech.Domain.Exceptions
{
    public class InvalidAssemblyWeightValueException : BaseException
    {
        public InvalidAssemblyWeightValueException(double value) : base($"Invalid assembly weight value: given {value}, required X > 0")
        {
        }
    }
}
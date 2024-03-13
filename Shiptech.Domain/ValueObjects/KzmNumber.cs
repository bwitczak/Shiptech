using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record KzmNumber(string? Value)
    {
        public static implicit operator string?(KzmNumber kzmNumber) => kzmNumber.Value;
        public static implicit operator KzmNumber(string? kzmNumber) => new(kzmNumber);
    }
}
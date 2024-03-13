using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Lot(string? Value)
    {
        public static implicit operator string?(Lot lot) => lot.Value;
        public static implicit operator Lot(string? lot) => new(lot);
    }
}
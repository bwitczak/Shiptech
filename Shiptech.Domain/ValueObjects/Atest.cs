using Shiptech.Domain.Consts;
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Atest(string? Value)
    {
        public static implicit operator string?(Atest atest) => atest.Value;
        public static implicit operator Atest(string? atest) => new(atest);
    }
}
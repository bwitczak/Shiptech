using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record D1II(short? Value)
    {
        public static implicit operator short?(D1II d1II) => d1II.Value;
        public static implicit operator D1II(short? d1II) => new(d1II);
    }
}
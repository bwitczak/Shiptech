namespace Shiptech.Domain.ValueObjects
{
    public record D1I(short? Value)
    {
        public static implicit operator short?(D1I d1I) => d1I.Value;
        public static implicit operator D1I(short? d1I) => new(d1I);
    }
}
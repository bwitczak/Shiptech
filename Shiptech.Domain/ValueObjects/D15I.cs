namespace Shiptech.Domain.ValueObjects
{
    public record D15I(short? Value)
    {
        public static implicit operator short?(D15I d15I) => d15I.Value;
        public static implicit operator D15I(short? d15I) => new(d15I);
    }
}
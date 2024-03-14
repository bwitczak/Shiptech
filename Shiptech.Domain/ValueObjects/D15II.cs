namespace Shiptech.Domain.ValueObjects
{
    public record D15II(short? Value)
    {
        public static implicit operator short?(D15II d15II) => d15II.Value;
        public static implicit operator D15II(short? d15II) => new(d15II);
    }
}
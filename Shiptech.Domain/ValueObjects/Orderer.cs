namespace Shiptech.Domain.ValueObjects
{
    public record Orderer(string Value)
    {
        public static implicit operator string(Orderer orderer) => orderer.Value;
        public static implicit operator Orderer(string orderer) => new(orderer);
    }
}
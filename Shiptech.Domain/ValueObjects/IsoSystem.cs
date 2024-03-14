namespace Shiptech.Domain.ValueObjects
{
    public record IsoSystem(string Value)
    {
        public static implicit operator string(IsoSystem isoId) => isoId.Value;
        public static implicit operator IsoSystem(string isoId) => new(isoId);
    }
}
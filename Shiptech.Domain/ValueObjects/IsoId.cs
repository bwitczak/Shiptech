namespace Shiptech.Domain.ValueObjects
{
    public record IsoId(string Value)
    {
        public static implicit operator string(IsoId isoId) => isoId.Value;
        public static implicit operator IsoId(string isoId) => new(isoId);
    }
}
namespace Shiptech.Domain.ValueObjects
{
    public record IsoName(string Value)
    {
        public static implicit operator string(IsoName isoName) => isoName.Value;
        public static implicit operator IsoName(string isoId) => new(isoId);
    }
}
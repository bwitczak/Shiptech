namespace Shiptech.Domain.ValueObjects
{
    public record Id(Guid Value)
    {
        public static implicit operator Guid(Id id) => id.Value;
        public static implicit operator Id(Guid id) => new(id);
    }
}
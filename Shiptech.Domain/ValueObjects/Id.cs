namespace Shiptech.Domain.ValueObjects
{
    public record Id(Ulid Value)
    {
        public static implicit operator Ulid(Id id) => id.Value;
        public static implicit operator Id(Ulid id) => new(id);
    }
}
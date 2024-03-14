namespace Shiptech.Domain.ValueObjects
{
    public record Revision(char Value)
    {
        public static implicit operator char(Revision revision) => revision.Value;
        public static implicit operator Revision(char revision) => new(revision);
    }
}
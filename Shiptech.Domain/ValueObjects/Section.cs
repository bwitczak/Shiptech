namespace Shiptech.Domain.ValueObjects
{
    public record Section(List<string>? Value)
    {
        public static implicit operator List<string>?(Section section) => section.Value;
        public static implicit operator Section(List<string>? section) => new(section);
    }
}
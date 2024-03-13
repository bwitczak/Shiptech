using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Section(string? Value)
    {
        public static implicit operator string?(Section section) => section.Value;
        public static implicit operator Section(string? section) => new(section);
    }
}
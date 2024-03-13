using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record DrawingId(string Value)
    {
        public static implicit operator string(DrawingId drawingId) => drawingId.Value;
        public static implicit operator DrawingId(string drawingId) => new(drawingId);
    }
}
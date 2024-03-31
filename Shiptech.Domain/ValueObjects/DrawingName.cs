namespace Shiptech.Domain.ValueObjects
{
    public record DrawingName(string Value)
    {
        public static implicit operator string(DrawingName drawingName) => drawingName.Value;
        public static implicit operator DrawingName(string drawingId) => new(drawingId);
    }
}
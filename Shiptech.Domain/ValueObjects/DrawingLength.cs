namespace Shiptech.Domain.ValueObjects
{
    public record DrawingLength(ushort? Value)
    {
        public static implicit operator ushort?(DrawingLength drawingLength) => drawingLength.Value;
        public static implicit operator DrawingLength(ushort? drawingLength) => new(drawingLength);
    }
}
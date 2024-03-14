namespace Shiptech.Domain.ValueObjects
{
    public record DrawingLength(short? Value)
    {
        public static implicit operator short?(DrawingLength drawingLength) => drawingLength.Value;
        public static implicit operator DrawingLength(short? drawingLength) => new(drawingLength);
    }
}
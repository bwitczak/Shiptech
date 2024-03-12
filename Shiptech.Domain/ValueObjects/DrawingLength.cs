using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record DrawingLength
    {
        public short? Value { get; }

        public DrawingLength(short? value)
        {
            if (value is < 0)
            {
                throw new InvalidDrawingLengthException(value);
            }

            Value = value;
        }

        public static implicit operator short?(DrawingLength drawingLength) => drawingLength.Value;
        public static implicit operator DrawingLength(short? drawingLength) => new(drawingLength);
    }
}
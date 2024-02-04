using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record DrawingLength
    {
        public int? Value { get; }

        public DrawingLength(int? value)
        {
            if (value is < 0)
            {
                throw new InvalidDrawingLengthException(value);
            }

            Value = value;
        }

        public static implicit operator int?(DrawingLength drawingLength) => drawingLength.Value;
        public static implicit operator DrawingLength(int? drawingLength) => new(drawingLength);
    }
}
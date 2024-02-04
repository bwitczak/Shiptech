using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record DrawingId
    {
        public string Value { get; }

        public DrawingId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyOrNullDrawingIdException();
            }

            if (value.Split("-").Length != 2)
            {
                throw new InvalidDrawingIdFormatException(value);
            }

            Value = value;
        }

        public static implicit operator string(DrawingId drawingId) => drawingId.Value;
        public static implicit operator DrawingId(string drawingId) => new(drawingId);
    }
}
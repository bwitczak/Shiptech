using FluentValidation.Results;

namespace Shiptech.Application.Exceptions
{
    internal sealed class InvalidDrawingLengthException : ValidationFailure
    {
        internal InvalidDrawingLengthException(short? drawingLength) : base(nameof(drawingLength),$"Długość rysunku {drawingLength}mm jest < 0!")
        {
        }
    }
}
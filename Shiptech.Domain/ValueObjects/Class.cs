using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Class(string Value)
    {
        public static implicit operator string(Class @class) => @class.Value;
        public static implicit operator Class(string @class) => new(@class);
    }
}
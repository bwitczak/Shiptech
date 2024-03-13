using Shiptech.Domain.Consts;
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Stage(string? Value)
    {
        public static implicit operator string?(Stage stage) => stage.Value;
        public static implicit operator Stage(string? stage) => new(stage);
    }
}
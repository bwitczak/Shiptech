using Shiptech.Domain.Consts;
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Stage
    {
        public string? Value { get; }

        public Stage(string? value)
        {
            // if (!value.HasFlag(value))
            // {
            //     throw new InvalidStageValueException(value);
            // }

            Value = value;
        }

        public static implicit operator string?(Stage stage) => stage.Value;
        public static implicit operator Stage(string? stage) => new(stage);
    }
}
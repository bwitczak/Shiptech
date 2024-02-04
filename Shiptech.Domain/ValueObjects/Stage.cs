using Shiptech.Domain.Consts;
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record Stage
    {
        public StageEnum Value { get; }

        public Stage(StageEnum value)
        {
            if (!value.HasFlag(value))
            {
                throw new InvalidStageValueException(value);
            }

            Value = value;
        }

        public static implicit operator StageEnum(Stage stage) => stage.Value;
        public static implicit operator Stage(StageEnum stage) => new(stage);
    }
}
using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationLength
    {
        public short Value { get; }

        public PrefabricationLength(short value)
        {
            if (value < 0)
            {
                throw new InvalidPrefabricationLengthValueException(value);
            }

            Value = value;
        }

        public static implicit operator short(PrefabricationLength prefabricationLength) => prefabricationLength.Value;
        public static implicit operator PrefabricationLength(short prefabricationLength) => new(prefabricationLength);
    }
}
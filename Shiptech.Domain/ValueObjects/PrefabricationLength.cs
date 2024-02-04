using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationLength
    {
        public int Value { get; }

        public PrefabricationLength(int value)
        {
            if (value < 0)
            {
                throw new InvalidPrefabricationLengthValueException(value);
            }

            Value = value;
        }

        public static implicit operator int(PrefabricationLength prefabricationLength) => prefabricationLength.Value;
        public static implicit operator PrefabricationLength(int prefabricationLength) => new(prefabricationLength);
    }
}
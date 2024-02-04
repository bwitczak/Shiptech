using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationQuantity
    {
        public int Value { get; }

        public PrefabricationQuantity(int value)
        {
            if (value < 0)
            {
                throw new InvalidPrefabricationQuantityValueException(value);
            }

            Value = value;
        }

        public static implicit operator int(PrefabricationQuantity prefabricationQuantity) => prefabricationQuantity.Value;
        public static implicit operator PrefabricationQuantity(int prefabricationQuantity) => new(prefabricationQuantity);
    }
}
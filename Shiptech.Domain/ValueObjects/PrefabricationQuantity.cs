using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationQuantity
    {
        public short Value { get; }

        public PrefabricationQuantity(short value)
        {
            if (value < 0)
            {
                throw new InvalidPrefabricationQuantityValueException(value);
            }

            Value = value;
        }

        public static implicit operator short(PrefabricationQuantity prefabricationQuantity) => prefabricationQuantity.Value;
        public static implicit operator PrefabricationQuantity(short prefabricationQuantity) => new(prefabricationQuantity);
    }
}
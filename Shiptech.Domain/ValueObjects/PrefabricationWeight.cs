using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationWeight
    {
        public double Value { get; }

        public PrefabricationWeight(double value)
        {
            if (value < 0)
            {
                throw new InvalidPrefabricationWeightValueException(value);
            }

            Value = value;
        }

        public static implicit operator double(PrefabricationWeight prefabricationWeight) => prefabricationWeight.Value;
        public static implicit operator PrefabricationWeight(double prefabricationWeight) => new(prefabricationWeight);
    }
}
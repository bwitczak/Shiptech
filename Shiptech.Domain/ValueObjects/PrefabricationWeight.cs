namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationWeight(double Value)
    {
        public static implicit operator double(PrefabricationWeight prefabricationWeight) => prefabricationWeight.Value;
        public static implicit operator PrefabricationWeight(double prefabricationWeight) => new(prefabricationWeight);
    }
}
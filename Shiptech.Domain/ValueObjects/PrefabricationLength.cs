namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationLength(short Value)
    {
        public static implicit operator short(PrefabricationLength prefabricationLength) => prefabricationLength.Value;
        public static implicit operator PrefabricationLength(short prefabricationLength) => new(prefabricationLength);
    }
}
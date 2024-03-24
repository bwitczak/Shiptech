namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationLength(ushort Value)
    {
        public static implicit operator ushort(PrefabricationLength prefabricationLength) => prefabricationLength.Value;
        public static implicit operator PrefabricationLength(ushort prefabricationLength) => new(prefabricationLength);
    }
}
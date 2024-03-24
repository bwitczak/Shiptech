namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationQuantity(ushort Value)
    {
        public static implicit operator ushort(PrefabricationQuantity prefabricationQuantity) => prefabricationQuantity.Value;
        public static implicit operator PrefabricationQuantity(ushort prefabricationQuantity) => new(prefabricationQuantity);
    }
}
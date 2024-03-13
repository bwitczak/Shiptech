using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects
{
    public record PrefabricationQuantity(short Value)
    {
        public static implicit operator short(PrefabricationQuantity prefabricationQuantity) => prefabricationQuantity.Value;
        public static implicit operator PrefabricationQuantity(short prefabricationQuantity) => new(prefabricationQuantity);
    }
}
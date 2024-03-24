namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyQuantity(ushort Value)
    {
        public static implicit operator ushort(AssemblyQuantity assemblyQuantity) => assemblyQuantity.Value;
        public static implicit operator AssemblyQuantity(ushort assemblyQuantity) => new(assemblyQuantity);
    }
}
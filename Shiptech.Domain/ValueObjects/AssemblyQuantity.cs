namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyQuantity(short Value)
    {
        public static implicit operator short(AssemblyQuantity assemblyQuantity) => assemblyQuantity.Value;
        public static implicit operator AssemblyQuantity(short assemblyQuantity) => new(assemblyQuantity);
    }
}
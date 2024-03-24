namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyLength(ushort Value)
    {
        public static implicit operator ushort(AssemblyLength assemblyLength) => assemblyLength.Value;
        public static implicit operator AssemblyLength(ushort assemblyLength) => new(assemblyLength);
    }
}
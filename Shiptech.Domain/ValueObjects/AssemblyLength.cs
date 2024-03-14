namespace Shiptech.Domain.ValueObjects
{
    public record AssemblyLength(short Value)
    {
        public static implicit operator short(AssemblyLength assemblyLength) => assemblyLength.Value;
        public static implicit operator AssemblyLength(short assemblyLength) => new(assemblyLength);
    }
}
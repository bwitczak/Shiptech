namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryLength(ushort? Value)
{
    public static implicit operator ushort?(AssortmentDictionaryLength length) => length.Value;
    public static implicit operator AssortmentDictionaryLength(ushort? length) => new(length);
};
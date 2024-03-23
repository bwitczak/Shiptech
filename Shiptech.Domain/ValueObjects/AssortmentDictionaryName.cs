namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryName(string Value)
{
    public static implicit operator string(AssortmentDictionaryName name) => name.Value;
    public static implicit operator AssortmentDictionaryName(string name) => new(name);
};
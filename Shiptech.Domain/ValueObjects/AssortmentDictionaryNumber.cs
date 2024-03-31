namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryNumber(string Value)
{
    public static implicit operator string(AssortmentDictionaryNumber number) => number.Value;
    public static implicit operator AssortmentDictionaryNumber(string id) => new(id);
};
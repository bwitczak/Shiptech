namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryId(string Value)
{
    public static implicit operator string(AssortmentDictionaryId id) => id.Value;
    public static implicit operator AssortmentDictionaryId(string id) => new(id);
};
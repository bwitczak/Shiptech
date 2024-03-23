namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryKind(string? Value)
{
    public static implicit operator string?(AssortmentDictionaryKind kind) => kind.Value;
    public static implicit operator AssortmentDictionaryKind(string kind) => new(kind);
};
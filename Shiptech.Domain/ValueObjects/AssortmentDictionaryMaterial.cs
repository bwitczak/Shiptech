namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryMaterial(string? Value)
{
    public static implicit operator string?(AssortmentDictionaryMaterial material) => material.Value;
    public static implicit operator AssortmentDictionaryMaterial(string material) => new(material);
};
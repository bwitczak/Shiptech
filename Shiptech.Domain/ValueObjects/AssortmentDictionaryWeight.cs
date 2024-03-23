namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryWeight(double Value)
{
    public static implicit operator double(AssortmentDictionaryWeight weight) => weight.Value;
    public static implicit operator AssortmentDictionaryWeight(double weight) => new(weight);
};
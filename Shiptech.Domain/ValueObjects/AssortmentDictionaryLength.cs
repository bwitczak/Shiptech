namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryLength(double Value)
{
    public static implicit operator double(AssortmentDictionaryLength length) => length.Value;
    public static implicit operator AssortmentDictionaryLength(double length) => new(length);
};
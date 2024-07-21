namespace Shiptech.Domain.ValueObjects;

public record AssortmentDictionaryAmount(double? Value)
{
    public static implicit operator double?(AssortmentDictionaryAmount amount) => amount.Value;
    public static implicit operator AssortmentDictionaryAmount(double? amount) => new(amount);
};
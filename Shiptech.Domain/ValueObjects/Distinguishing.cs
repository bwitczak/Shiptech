namespace Shiptech.Domain.ValueObjects;

public record Distinguishing(string Value)
{
    public static implicit operator string(Distinguishing distinguishing) => distinguishing.Value;
    public static implicit operator Distinguishing(string distinguishing) => new(distinguishing);
};
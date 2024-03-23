namespace Shiptech.Domain.ValueObjects;

public record RO(string Value)
{
    public static implicit operator string(RO ro) => ro.Value;
    public static implicit operator RO(string ro) => new(ro);
};
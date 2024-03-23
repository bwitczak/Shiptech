namespace Shiptech.Domain.ValueObjects;

public record Unit(string Value)
{
    public static implicit operator string(Unit id) => id.Value;
    public static implicit operator Unit(string id) => new(id);
};
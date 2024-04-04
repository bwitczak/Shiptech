namespace Shiptech.Domain.ValueObjects;

public record ShipCode(string Value)
{
    public static implicit operator string(ShipCode shipCode) => shipCode.Value;
    public static implicit operator ShipCode(string shipCode) => new(shipCode);
}
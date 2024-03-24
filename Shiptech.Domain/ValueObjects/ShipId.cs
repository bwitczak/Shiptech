namespace Shiptech.Domain.ValueObjects;

public record ShipId(Guid Value)
{
    public static implicit operator Guid(ShipId shipId) => shipId.Value;
    public static implicit operator ShipId(Guid shipId) => new(shipId);
}

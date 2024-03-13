using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects;

public record ShipId(string Value)
{
    public static implicit operator string(ShipId shipId) => shipId.Value;
    public static implicit operator ShipId(string shipId) => new(shipId);
}

using Shiptech.Domain.Exceptions;

namespace Shiptech.Domain.ValueObjects;

public record ShipId
{
    public string Value { get; }

    public ShipId(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyOrNullShipIdException();
        }

        Value = value;
    }

    public static implicit operator string(ShipId shipId) => shipId.Value;
    public static implicit operator ShipId(string shipId) => new(shipId);
}

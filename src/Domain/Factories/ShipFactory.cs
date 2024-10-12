using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class ShipFactory : IShipFactory
{
    public Ship Create(Ulid id, string code, Shipowner shipowner)
    {
        return new Ship { Id = id, Code = code, Shipowner = shipowner };
    }
}

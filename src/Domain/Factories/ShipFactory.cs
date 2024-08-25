using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class ShipFactory : IShipFactory
{
    public Ship Create(Ulid id, string code, string orderer)
    {
        return new Ship { Id = id, Code = code, Orderer = orderer };
    }
}

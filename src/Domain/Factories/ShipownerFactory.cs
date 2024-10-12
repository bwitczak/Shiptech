using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class ShipownerFactory : IShipownerFactory
{
    public Shipowner Create(Ulid id, string orderer)
    {
        return new Shipowner { Id = id, Orderer = orderer };
    }
}

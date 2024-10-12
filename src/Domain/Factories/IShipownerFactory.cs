using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IShipownerFactory
{
    Shipowner Create(Ulid id, string orderer);
}

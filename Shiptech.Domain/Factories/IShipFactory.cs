using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IShipFactory
    {
        Ship Create(ShipId id, Orderer orderer);
    }
}
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IShipFactory
    {
        Ship Create(Id id, ShipCode code, Orderer orderer);
    }
}
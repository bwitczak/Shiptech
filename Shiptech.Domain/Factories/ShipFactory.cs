using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class ShipFactory : IShipFactory
    {
        public Ship Create(Id id, ShipCode code, Orderer orderer)
            => new(id, code, orderer);
    }
}
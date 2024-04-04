using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class ShipFactory : IShipFactory
    {
        public Ship Create(Id id, Orderer orderer)
            => new(id, orderer);
    }
}
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public sealed class Ship
    {
        public ShipId Id { get; private set; }
        private Orderer _orderer;
        private IEnumerable<Drawing> _drawings;

        private Ship()
        {
        }

        internal Ship(ShipId id, Orderer orderer)
        {
            Id = id;
            _orderer = orderer;
        }
    }
}
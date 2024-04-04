using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public sealed class Ship
    {
        public Id Id { get; private set; }
        private ShipCode _code;
        private Orderer _orderer;
        private IEnumerable<Drawing> _drawings;

        private Ship()
        {
        }

        internal Ship(Id id, ShipCode code, Orderer orderer)
        {
            Id = id;
            _code = code;
            _orderer = orderer;
        }
    }
}
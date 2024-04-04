using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public sealed class Ship
    {
        public Id Id { get; private set; }
        private Orderer _orderer;
        private IEnumerable<Drawing> _drawings;

        private Ship()
        {
        }

        internal Ship(Id id, Orderer orderer)
        {
            Id = id;
            _orderer = orderer;
        }
    }
}
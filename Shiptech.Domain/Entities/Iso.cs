using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public class Iso
    {
        public IsoId Id { get; private set; }
        private Revision _isoRevision;
        private IsoSystem _system;
        private Class _class;
        private Atest _atest;
        private KzmNumber _kzmNumber;
        private Date _kzmDate;
        private IEnumerable<Assortment> _assortments;

        // TODO: Chemical process

        private Iso()
        {
        }

        internal Iso(IsoId id, Revision isoRevision, IsoSystem system, Class @class, Atest atest, KzmNumber kzmNumber,
            Date kzmDate)
        {
            Id = id;
            _isoRevision = isoRevision;
            _system = system;
            _class = @class;
            _atest = atest;
            _kzmNumber = kzmNumber;
            _kzmDate = kzmDate;
        }
    }
}
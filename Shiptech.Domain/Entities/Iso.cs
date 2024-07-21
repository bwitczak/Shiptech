using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Entities
{
    public class Iso
    {
        public Ulid Id { get; private set; }
        private IsoName _name;
        private Revision _isoRevision;
        private IsoSystem _system;
        private Class _class;
        private Atest _atest;
        private KzmNumber _kzmNumber;
        private KzmDate _kzmKzmDate;
        private ChemicalProcess _chemicalProcess;
        private IEnumerable<Assortment> _assortments;

        private Iso()
        {
        }

        internal Iso(Id id, IsoName name, Revision isoRevision, IsoSystem system, Class @class, Atest atest, KzmNumber kzmNumber,
            KzmDate kzmKzmDate)
        {
            Id = id;
            _name = name;
            _isoRevision = isoRevision;
            _system = system;
            _class = @class;
            _atest = atest;
            _kzmNumber = kzmNumber;
            _kzmKzmDate = kzmKzmDate;
        }
    }
}
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class IsoFactory : IIsoFactory
    {
        public Iso Create(Id id, IsoName name, Revision isoRevision, IsoSystem system, Class @class, Atest atest, KzmNumber kzmNumber, KzmDate kzmKzmDate)
            => new(id, name, isoRevision, system, @class, atest, kzmNumber, kzmKzmDate);
    }
}
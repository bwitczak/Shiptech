using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public sealed class IsoFactory : IIsoFactory
    {
        public Iso Create(IsoId id, Revision isoRevision, IsoSystem system, Class @class, Atest atest, KzmNumber kzmNumber, Date kzmDate)
            => new(id, isoRevision, system, @class, atest, kzmNumber, kzmDate);
    }
}
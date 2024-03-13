using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IIsoFactory
    {
        Iso Create(IsoId id, Revision isoRevision, IsoSystem system, Class @class, Atest atest, KzmNumber kzmNumber, KzmDate kzmKzmDate);
    }
}
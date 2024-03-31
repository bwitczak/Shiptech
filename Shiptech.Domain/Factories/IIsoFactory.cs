using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Factories
{
    public interface IIsoFactory
    {
        Iso Create(Id id, IsoName name, Revision isoRevision, IsoSystem system, Class @class, Atest atest, KzmNumber kzmNumber, KzmDate kzmKzmDate);
    }
}
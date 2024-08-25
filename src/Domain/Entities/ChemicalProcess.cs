using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class ChemicalProcess : BaseEntity
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public IList<Iso> Isos { get; private set; } = new List<Iso>();
}

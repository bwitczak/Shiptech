using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class Shipowner : BaseEntity
{
    public required string Orderer { get; set; }
    public IEnumerable<Ship>? Ships { get; set; }
}

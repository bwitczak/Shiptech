using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class Ship : BaseEntity
{
    public required string Code { get; set; }
    public required string Orderer { get; set; }
    public IList<Drawing> Drawings { get; private set; } = new List<Drawing>();
}

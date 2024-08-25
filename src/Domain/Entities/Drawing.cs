using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class Drawing : BaseAuditableEntity
{
    public required string Number { get; set; }
    public required string Name { get; set; }
    public char Revision {get; set;}
    public string? Lot {get; set;}
    public string? Block {get; set;}
    public IList<string>? Section {get; set;}
    public string? Stage {get; set;}
    public Ship? Ship { get; set; }
    public IList<Iso> Isos { get; private set; } = new List<Iso>();
}

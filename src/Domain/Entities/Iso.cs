using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class Iso : BaseAuditableEntity
{
    public required string Number { get; set; }
    public required string Nameplate  { get; set; }
    public char Revision { get; set; }
    public required string System { get; set; }
    public required string Class { get; set; }
    public string? Atest { get; set; }
    public string? KzmNumber { get; set; }
    public DateOnly? KzmDate { get; set; }
    public Drawing? Drawing { get; set; }
    public ChemicalProcess? ChemicalProcess { get; set; }
    public IList<Assortment> Assortments { get; private set; } = new List<Assortment>();
}

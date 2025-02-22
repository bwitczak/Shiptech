using NpgsqlTypes;
using Shiptech.Domain.Common;

namespace Shiptech.Domain.Entities;

public class AssortmentDictionary : BaseEntity
{
    public required string Number { get; set; }
    public required string Name { get; set; }
    public string? Distinguishing { get; set; }
    public required string Unit { get; set; }
    public double? Amount { get; set; }
    public double? Weight { get; set; }
    public string? Material { get; set; }
    public string? Kind { get; set; }
    public string? DN1 { get; set; }
    public string? DN2 { get; set; }
    public ushort? Length { get; set; }
    public string? RA { get; set; }
    public string? NS { get; set; }
    public string? Comment { get; set; }

    public NpgsqlTsVector SearchVector { get; init; } = null!;
    public IList<Assortment> Assortments { get; set; } = new List<Assortment>();
}

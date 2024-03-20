using Shiptech.Infrastructure.EF.Models.Consts;

namespace Shiptech.Infrastructure.EF.Models;

internal class IsoReadModel
{
    public string Id { get; set; }
    public char IsoRevision { get; set; }
    public string System { get; set; }
    public string Class { get; set; }
    public string? Atest { get; set; }
    public string? KzmNumber { get; set; }
    public DateTime? KzmDate { get; set; }
    public DrawingReadModel Drawing { get; set; }
    public ChemicalProcessReadModel ChemicalProcess { get; set; }
    public ICollection<AssortmentReadModel> Assortments { get; set; }
}
using Shiptech.Infrastructure.EF.Models.Consts;

namespace Shiptech.Infrastructure.EF.Models;

internal class IsoReadModel
{
    public string Id { get; set; }
    public string IsoRevision { get; set; }
    public string System { get; set; }
    public string Class { get; set; }
    public AtestEnum? Atest { get; set; }
    public string? KzmNumber { get; set; }
    public string? KzmDate { get; set; } // TODO: Change string to DateTime
    public DrawingReadModel Drawing { get; set; }
    public ICollection<AssortmentReadModel> Assortments { get; set; }

    // TODO: Add ChemicalProcess
}
namespace Shiptech.Infrastructure.EF.Models;

internal class ChemicalProcessReadModel
{
    public string Id { get; set; }
    public string ChemicalProcessName { get; set; }
    public IEnumerable<IsoReadModel> Isos { get; set; }
}
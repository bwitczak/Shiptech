namespace Shiptech.Infrastructure.EF.Models;

internal class ChemicalProcessReadModel
{
    public Ulid Id { get; set; }
    public string ChemicalProcessCode { get; set; }
    public string ChemicalProcessName { get; set; }
    public IEnumerable<IsoReadModel> Isos { get; set; }
}
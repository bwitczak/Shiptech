using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public class IsoFactory : IIsoFactory
{
    public Iso Create(Ulid id, string number, string nameplate, char revision, string system, string @class, string? atest, string? kzmNumber, DateOnly? kzmDate, Drawing drawing, ChemicalProcess chemicalProcess)
    {
        return new Iso { Id = id, Number = number, Nameplate = nameplate, Revision = revision, System = system, Class = @class, Atest = atest, KzmNumber = kzmNumber, KzmDate = kzmDate, Drawing =  drawing, ChemicalProcess = chemicalProcess};
    }
}

using Shiptech.Domain.Entities;

namespace Shiptech.Domain.Factories;

public interface IIsoFactory
{
    Iso Create(Ulid id, string name, string nameplate, string revision, string system, string @class, string? atest,
        string? kzmNumber, DateOnly? kzmDate, Drawing drawing, ChemicalProcess chemicalProcess);
}

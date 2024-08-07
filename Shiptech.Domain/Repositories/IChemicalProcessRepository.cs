using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IChemicalProcessRepository
    {
        Task<ChemicalProcess> GetAsync(Ulid id);
        Task CreateAsync(ChemicalProcess chemicalProcess);
        Task UpdateAsync(ChemicalProcess chemicalProcess);
        Task DeleteAsync(ChemicalProcess chemicalProcess);
    }
}
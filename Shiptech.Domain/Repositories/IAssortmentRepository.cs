using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IAssortmentRepository
    {
        Task<Assortment> GetAsync(AssortmentId id);
        Task CreateAsync(Assortment assortment);
        Task UpdateAsync(Assortment assortment);
        Task DeleteAsync(AssortmentId id);
    }
}
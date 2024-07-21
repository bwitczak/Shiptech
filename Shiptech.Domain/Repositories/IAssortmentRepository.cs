using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IAssortmentRepository
    {
        Task<Assortment> GetAsync(Ulid id);
        Task CreateAsync(Assortment assortment);
        Task UpdateAsync(Assortment assortment);
        Task DeleteAsync(Assortment assortment);
    }
}
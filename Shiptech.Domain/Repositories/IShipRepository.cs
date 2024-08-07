using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IShipRepository
    {
        Task<Ship> GetAsync(Ulid id);
        Task CreateAsync(Ship ship);
        Task UpdateAsync(Ship ship);
        Task DeleteAsync(Ship ship);
    }
}
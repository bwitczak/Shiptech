using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IIsoRepository
    {
        Task<Iso> GetAsync(IsoId id);
        Task CreateAsync(Iso iso);
        Task UpdateAsync(Iso iso);
        Task DeleteAsync(IsoId id);
    }
}
using Shiptech.Domain.Entities;
using Shiptech.Domain.ValueObjects;

namespace Shiptech.Domain.Repositories
{
    public interface IDrawingRepository
    {
        Task<Drawing> GetAsync(Ulid id);
        Task CreateAsync(Drawing drawing);
        Task UpdateAsync(Drawing drawing);
        Task DeleteAsync(Drawing drawing);
    }
}
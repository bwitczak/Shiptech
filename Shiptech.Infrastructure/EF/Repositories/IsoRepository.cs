using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Repositories;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Contexts;

namespace Shiptech.Infrastructure.EF.Repositories;

internal sealed class IsoRepository() : IIsoRepository
{
    private readonly DbSet<Iso> _isos; 
    private readonly WriteDbContext _dbContext;

    public IsoRepository(WriteDbContext dbContext) : this()
    {
        _isos = dbContext.Iso;
        _dbContext = dbContext;
    }

    public async Task<Iso> GetAsync(Id id)
    {
        return await _isos.AsNoTracking().SingleAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Iso iso)
    {
        await _isos.AddAsync(iso);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Iso iso)
    {
        _isos.Update(iso);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Iso iso)
    {
        _isos.Remove(iso);
        await _dbContext.SaveChangesAsync();
    }
}
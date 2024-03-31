using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Repositories;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Contexts;

namespace Shiptech.Infrastructure.EF.Repositories;

internal sealed class AssortmentRepository() : IAssortmentRepository
{
    private readonly DbSet<Assortment> _assortments; 
    private readonly WriteDbContext _dbContext;
    
    public AssortmentRepository(WriteDbContext dbContext) : this()
    {
        _assortments = dbContext.Assortment;
        _dbContext = dbContext;
    }
    
    public async Task<Assortment?> GetAsync(Id id)
    {
        return await _assortments.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Assortment assortment)
    {
        await _assortments.AddAsync(assortment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Assortment assortment)
    {
        _assortments.Update(assortment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Assortment assortment)
    {
        _assortments.Remove(assortment);
        await _dbContext.SaveChangesAsync();
    }
}
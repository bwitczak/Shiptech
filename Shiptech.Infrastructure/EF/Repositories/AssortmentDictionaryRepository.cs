using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Repositories;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Contexts;

namespace Shiptech.Infrastructure.EF.Repositories;

internal sealed class AssortmentDictionaryRepository() : IAssortmentDictionaryRepository
{
    private readonly DbSet<AssortmentDictionary> _assortmentDictionaries; 
    private readonly WriteDbContext _dbContext;
    
    public AssortmentDictionaryRepository(WriteDbContext dbContext) : this()
    {
        _assortmentDictionaries = dbContext.AssortmentDictionary;
        _dbContext = dbContext;
    }
    
    public async Task<AssortmentDictionary> GetAsync(Ulid id)
    {
        return await _assortmentDictionaries.AsNoTracking().SingleAsync(x => x.Id == id);
    }

    public async Task CreateAsync(AssortmentDictionary assortmentDictionary)
    {
        await _assortmentDictionaries.AddAsync(assortmentDictionary);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(AssortmentDictionary assortmentDictionary)
    {
        _assortmentDictionaries.Update(assortmentDictionary);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(AssortmentDictionary assortmentDictionary)
    {
        _assortmentDictionaries.Remove(assortmentDictionary);
        await _dbContext.SaveChangesAsync();
    }
}
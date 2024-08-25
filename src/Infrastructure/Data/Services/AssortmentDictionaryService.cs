using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class AssortmentDictionaryService : IAssortmentDictionaryService
{
    private readonly DbSet<AssortmentDictionary> _assortmentDictionary;

    public AssortmentDictionaryService(IApplicationDbContext context)
    {
        _assortmentDictionary = context.AssortmentDictionaries;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _assortmentDictionary.AnyAsync(x => x.Id == id);
    }
}

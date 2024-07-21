using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Services;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Services;

internal sealed class AssortmentDictionaryService() : IAssortmentDictionaryReadService
{
    private readonly DbSet<AssortmentDictionaryReadModel> _assortmentDictionary;

    public AssortmentDictionaryService(ReadDbContext context) : this()
    {
        _assortmentDictionary = context.AssortmentDictionary;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _assortmentDictionary.AnyAsync(x => x.Id == id);
    }
}
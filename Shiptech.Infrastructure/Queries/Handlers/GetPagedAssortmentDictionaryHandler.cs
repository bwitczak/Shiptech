using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetPagedAssortmentDictionaryHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetPagedAssortmentDictionary, IEnumerable<AssortmentDictionaryWithNoRelationsDto>>
{
    private readonly DbSet<AssortmentDictionaryReadModel> _assortmentDictionary = context.AssortmentDictionary;
    
    public async Task<IEnumerable<AssortmentDictionaryWithNoRelationsDto>> HandleAsync(GetPagedAssortmentDictionary query)
    {
        return await _assortmentDictionary.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
            .Select(x => mapper.Map<AssortmentDictionaryWithNoRelationsDto>(x)).ToListAsync();
    }
}
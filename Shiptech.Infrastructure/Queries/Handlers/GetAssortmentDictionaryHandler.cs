using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetAssortmentDictionaryHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetAssortmentDictionary, AssortmentDictionaryDto>
{
    private readonly DbSet<AssortmentDictionaryReadModel> _assortmentDictionary = context.AssortmentDictionary;

    public async Task<AssortmentDictionaryDto> HandleAsync(GetAssortmentDictionary query)
    {
        return await _assortmentDictionary
            .Where(x => x.Id == query.Id)
            .Select(x => mapper.Map<AssortmentDictionaryDto>(x))
            .AsNoTracking()
            .SingleAsync();
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetPagedDrawingsHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetPagedDrawings, IEnumerable<DrawingWithNoRelationsDto>>
{
    private readonly DbSet<DrawingReadModel> _drawings = context.Drawing;
    
    public async Task<IEnumerable<DrawingWithNoRelationsDto>> HandleAsync(GetPagedDrawings query)
    {
        return await _drawings.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
            .Select(x => mapper.Map<DrawingWithNoRelationsDto>(x)).ToListAsync();
    }
}
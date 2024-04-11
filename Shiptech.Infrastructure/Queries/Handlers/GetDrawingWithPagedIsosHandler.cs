using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetDrawingWithPagedIsosHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetDrawingWithPagedIsos, DrawingDto>
{
    private readonly DbSet<DrawingReadModel> _ships = context.Drawing;

    public async Task<DrawingDto> HandleAsync(GetDrawingWithPagedIsos query)
    {
        return await _ships
            .Include(x => x.Isos.Skip((query.IsoPageNumber - 1) * query.IsoPageSize).Take(query.IsoPageSize))
            .Where(x => x.Id == query.Id)
            .Select(x => mapper.Map<DrawingDto>(x))
            .AsNoTracking()
            .SingleAsync();
    }
}
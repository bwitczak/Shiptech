using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetShipWithPagedDrawingsHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetShipWithPagedDrawings, ShipDto>
{
    private readonly DbSet<ShipReadModel> _ships = context.Ship;

    public async Task<ShipDto> HandleAsync(GetShipWithPagedDrawings query)
    {
        return await _ships
            .Include(x => x.Drawings.Skip((query.DrawingPageNumber - 1) * query.DrawingPageSize).Take(query.DrawingPageSize))
            .Where(x => x.Id == query.Id)
            .Select(x => mapper.Map<ShipDto>(x))
            .AsNoTracking()
            .SingleAsync();
    }
}
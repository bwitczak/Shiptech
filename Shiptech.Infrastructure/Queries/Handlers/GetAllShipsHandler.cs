using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetAllShipsHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetAllShips, IEnumerable<ShipWithNoRelationsDto>>
{
    private readonly DbSet<ShipReadModel> _ships = context.Ship;

    public async Task<IEnumerable<ShipWithNoRelationsDto>> HandleAsync(GetAllShips query)
    {
        return await _ships.Select(x => mapper.Map<ShipWithNoRelationsDto>(x))
            .AsNoTracking().ToListAsync();
    }
}
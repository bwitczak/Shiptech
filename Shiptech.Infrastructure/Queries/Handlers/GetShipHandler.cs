using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetShipHandler(ReadDbContext context) : IQueryHandler<GetShip, ShipDto?>
{
    private readonly DbSet<ShipReadModel> _ships = context.Ship;

    public async Task<ShipDto?> HandleAsync(GetShip query)
    {
        return await _ships
            .Where(x => x.Id == query.Id)
            .Select(x => x.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
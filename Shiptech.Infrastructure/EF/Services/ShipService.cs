using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Services;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Services;

internal sealed class ShipService() : IShipReadService
{
    private readonly DbSet<ShipReadModel> _ships;

    public ShipService(ReadDbContext context) : this()
    {
        _ships = context.Ship;
    }

    public async Task<bool> ExistsById(Guid id)
    {
        return await _ships.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByOrderer(string orderer)
    {
        return await _ships.AnyAsync(x => x.Orderer == orderer);
    }
}
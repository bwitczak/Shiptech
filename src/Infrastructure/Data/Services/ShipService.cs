using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class ShipService : IShipService
{
    private readonly DbSet<Ship> _ships;

    public ShipService(ApplicationDbContext context)
    {
        _ships = context.Ships;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _ships.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByCode(string code)
    {
        return await _ships.AnyAsync(x => x.Code == code);
    }
}

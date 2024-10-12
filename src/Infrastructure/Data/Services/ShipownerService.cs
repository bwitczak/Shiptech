using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class ShipownerService : IShipownerService
{
    private readonly DbSet<Shipowner> _shipowners;

    public ShipownerService(ApplicationDbContext context)
    {
        _shipowners = context.Shipowners;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _shipowners.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByOrderer(string orderer)
    {
        return await _shipowners.AnyAsync(x => x.Orderer == orderer);
    }
}

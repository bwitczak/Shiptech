using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Repositories;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Contexts;

namespace Shiptech.Infrastructure.EF.Repositories;

internal sealed class ShipRepository() : IShipRepository
{
    private readonly DbSet<Ship> _ships;
    private readonly WriteDbContext _dbContext;

    public ShipRepository(WriteDbContext dbContext) : this()
    {
        _ships = dbContext.Ship;
        _dbContext = dbContext;
    }

    public async Task<Ship> GetAsync(Id id)
    {
        return await _ships.AsNoTracking().SingleAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Ship ship)
    {
        await _ships.AddAsync(ship);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ship ship)
    {
        _ships.Update(ship);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ship ship)
    {
        _ships.Remove(ship);
        await _dbContext.SaveChangesAsync();
    }
}
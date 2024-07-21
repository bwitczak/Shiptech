using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Repositories;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Contexts;

namespace Shiptech.Infrastructure.EF.Repositories;

internal sealed class DrawingRepository() : IDrawingRepository
{
    private readonly DbSet<Drawing> _drawings;
    private readonly WriteDbContext _dbContext;

    public DrawingRepository(WriteDbContext dbContext) : this()
    {
        _drawings = dbContext.Drawing;
        _dbContext = dbContext;
    }

    public async Task<Drawing> GetAsync(Ulid id)
    {
        return await _drawings.AsNoTracking().SingleAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Drawing drawing)
    {
        await _drawings.AddAsync(drawing);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Drawing drawing)
    {
        _drawings.Update(drawing);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Drawing drawing)
    {
        _drawings.Remove(drawing);
        await _dbContext.SaveChangesAsync();
    }
}
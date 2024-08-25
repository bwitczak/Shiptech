using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class DrawingService : IDrawingService
{
    private readonly DbSet<Drawing> _drawings;

    public DrawingService(IApplicationDbContext context)
    {
        _drawings = context.Drawings;
    }
    
    public async Task<bool> ExistsById(Ulid id)
    {
        return await _drawings.AnyAsync(x => x.Id == id);
    }
}

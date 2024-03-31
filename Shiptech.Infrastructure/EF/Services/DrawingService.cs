using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Services;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Services;

internal sealed class DrawingService() : IDrawingReadService
{
    private readonly DbSet<DrawingReadModel> _drawings;

    public DrawingService(ReadDbContext context) : this()
    {
        _drawings = context.Drawing;
    }

    public async Task<bool> ExistsById(Guid id)
    {
        return await _drawings.AnyAsync(x => x.Id == id);
    }
}
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Services;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Services;

internal sealed class IsoService() : IIsoReadService
{
    private readonly DbSet<IsoReadModel> _isos;

    public IsoService(ReadDbContext context) : this()
    {
        _isos = context.Iso;
    }

    public async Task<bool> ExistsById(string id)
    {
        return await _isos.AnyAsync(x => x.Id == id);
    }
}
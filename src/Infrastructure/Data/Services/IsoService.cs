using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class IsoService : IIsoService
{
    private readonly DbSet<Iso> _isos;

    public IsoService(IApplicationDbContext context)
    {
        _isos = context.Isos;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _isos.AnyAsync(x => x.Id == id);
    }
}

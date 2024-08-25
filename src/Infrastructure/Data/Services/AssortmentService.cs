using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class AssortmentService : IAssortmentService
{
    private readonly DbSet<Assortment> _assortments;

    public AssortmentService(IApplicationDbContext context)
    {
        _assortments = context.Assortments;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _assortments.AnyAsync(x => x.Id == id);
    }
}

using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Services;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Services;

internal sealed class AssortmentService() : IAssortmentReadService
{
    private readonly DbSet<AssortmentReadModel> _assortments;

    public AssortmentService(ReadDbContext context) : this()
    {
        _assortments = context.Assortment;
    }

    public async Task<bool> ExistsById(string id)
    {
        return await _assortments.AnyAsync(x => x.Id == id);
    }
}
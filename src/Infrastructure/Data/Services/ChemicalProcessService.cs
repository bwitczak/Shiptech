using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Domain.Entities;

namespace Shiptech.Infrastructure.Data.Services;

public class ChemicalProcessService : IChemicalProcessService
{
    private readonly DbSet<ChemicalProcess> _chemicalProcesses;

    public ChemicalProcessService(IApplicationDbContext context)
    {
        _chemicalProcesses = context.ChemicalProcesses;
    }

    public async Task<bool> ExistsById(Ulid id)
    {
        return await _chemicalProcesses.AnyAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByName(string name)
    {
        return await _chemicalProcesses.AnyAsync(x => x.Name == name);
    }
}

using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Services;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;

namespace Shiptech.Infrastructure.EF.Services;

internal sealed class ChemicalProcessService() : IChemicalProcessReadService
{
    private readonly DbSet<ChemicalProcessReadModel> _chemicalProcesses;

    public ChemicalProcessService(ReadDbContext context) : this()
    {
        _chemicalProcesses = context.ChemicalProcess;
    }

    public async Task<bool> ExistsById(Guid id)
    {
        return await _chemicalProcesses.AnyAsync(x => x.Id == id);
    }
}
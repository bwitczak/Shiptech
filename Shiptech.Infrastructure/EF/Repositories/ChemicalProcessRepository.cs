using Microsoft.EntityFrameworkCore;
using Shiptech.Domain.Entities;
using Shiptech.Domain.Repositories;
using Shiptech.Domain.ValueObjects;
using Shiptech.Infrastructure.EF.Contexts;

namespace Shiptech.Infrastructure.EF.Repositories;

internal sealed class ChemicalProcessRepository() : IChemicalProcessRepository
{
    private readonly DbSet<ChemicalProcess> _chemicalProcesses;
    private readonly WriteDbContext _dbContext;

    public ChemicalProcessRepository(WriteDbContext dbContext) : this()
    {
        _chemicalProcesses = _dbContext.ChemicalProcess;
        _dbContext = dbContext;
    }

    public async Task<ChemicalProcess?> GetAsync(Id id)
    {
        return await _chemicalProcesses.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(ChemicalProcess chemicalProcess)
    {
        await _chemicalProcesses.AddAsync(chemicalProcess);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ChemicalProcess chemicalProcess)
    {
        _chemicalProcesses.Update(chemicalProcess);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ChemicalProcess chemicalProcess)
    {
        _chemicalProcesses.Remove(chemicalProcess);
        await _dbContext.SaveChangesAsync();
    }
}
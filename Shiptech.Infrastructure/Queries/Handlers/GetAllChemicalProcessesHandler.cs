using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetAllChemicalProcessesHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetAllChemicalProcesses, IEnumerable<ChemicalProcessDto>>
{
    private readonly DbSet<ChemicalProcessReadModel> _chemicalProcess = context.ChemicalProcess;

    public async Task<IEnumerable<ChemicalProcessDto>> HandleAsync(GetAllChemicalProcesses query)
    {
        return await _chemicalProcess.Select(x => mapper.Map<ChemicalProcessDto>(x))
            .AsNoTracking().ToListAsync();
    }
}
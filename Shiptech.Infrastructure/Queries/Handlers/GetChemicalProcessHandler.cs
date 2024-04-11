using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Infrastructure.EF.Contexts;
using Shiptech.Infrastructure.EF.Models;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetChemicalProcessHandler(ReadDbContext context, IMapper mapper) : IQueryHandler<GetChemicalProcess, ChemicalProcessDto>
{
    private readonly DbSet<ShipReadModel> _chemicalProcess = context.Ship;

    public async Task<ChemicalProcessDto> HandleAsync(GetChemicalProcess query)
    {
        return await _chemicalProcess
            .Where(x => x.Id == query.Id)
            .Select(x => mapper.Map<ChemicalProcessDto>(x))
            .AsNoTracking()
            .SingleAsync();
    }
}
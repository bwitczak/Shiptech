using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Models.ChemicalProcess;

namespace Shiptech.Application.ChemicalProcesses.Queries.GetAllChemicalProcesses;

public record GetAllChemicalProcessesQuery : IRequest<IEnumerable<ChemicalProcessDto>>
{
}

public class
    GetAllChemicalProcessesQueryHandler : IRequestHandler<GetAllChemicalProcessesQuery, IEnumerable<ChemicalProcessDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllChemicalProcessesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ChemicalProcessDto>> Handle(GetAllChemicalProcessesQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.ChemicalProcesses.Select(x => _mapper.Map<ChemicalProcessDto>(x))
            .AsNoTracking().ToListAsync(cancellationToken);
    }
}

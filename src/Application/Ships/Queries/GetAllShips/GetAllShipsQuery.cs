using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Models.Ship;

namespace Shiptech.Application.Ships.Queries.GetAllShips;

public record GetAllShipsQuery : IRequest<IEnumerable<ShipWithNoRelationsDto>>
{
}

public class GetAllShipsQueryHandler : IRequestHandler<GetAllShipsQuery, IEnumerable<ShipWithNoRelationsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllShipsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShipWithNoRelationsDto>> Handle(GetAllShipsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Ships
            .AsNoTracking()
            .ProjectTo<ShipWithNoRelationsDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

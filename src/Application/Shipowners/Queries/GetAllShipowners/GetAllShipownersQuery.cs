using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Models.Shipowner;

namespace Shiptech.Application.Shipowners.Queries.GetAllShipowners;

public record GetAllShipownersQuery : IRequest<IEnumerable<ShipownerDto>>
{
}

public class
    GetAllShipownersQueryHandler : IRequestHandler<GetAllShipownersQuery, IEnumerable<ShipownerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllShipownersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShipownerDto>> Handle(GetAllShipownersQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Shipowners
            .AsNoTracking()
            .ProjectTo<ShipownerDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

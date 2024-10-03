using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Application.Common.Models.Drawing;

namespace Shiptech.Application.Drawings.Queries.GetDrawings;

public record GetPaginatedDrawingsQuery : IRequest<IEnumerable<DrawingWithNoRelationsDto>>
{
    public required string ShipOrderer { get; init; }
}

public class GetPaginatedDrawingsQueryValidator : AbstractValidator<GetPaginatedDrawingsQuery>
{
    public GetPaginatedDrawingsQueryValidator(IShipService service)
    {
        RuleFor(x => x.ShipOrderer)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_PAGINATED_DRAWINGS_400_SHIP_ORDERER")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsByOrderer(x))
            .WithMessage(x => $"{x.ShipOrderer} nie istnieje w bazie!")
            .WithErrorCode("SHIP_404_ORDERER");
    }
}

public class
    GetPaginatedDrawingsQueryHandler : IRequestHandler<GetPaginatedDrawingsQuery,
    IEnumerable<DrawingWithNoRelationsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPaginatedDrawingsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DrawingWithNoRelationsDto>> Handle(GetPaginatedDrawingsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Drawings
            .Where(x => x.Ship != null && x.Ship.Orderer == request.ShipOrderer)
            .OrderBy(x => x.Number)
            .ProjectTo<DrawingWithNoRelationsDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}

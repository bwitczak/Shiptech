using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Application.Common.Mappings;
using Shiptech.Application.Common.Models;
using Shiptech.Application.Common.Models.Drawing;

namespace Shiptech.Application.Drawings.Queries.GetPaginatedDrawings;

public record GetPaginatedDrawingsQuery : IRequest<PaginatedList<DrawingWithNoRelationsDto>>
{
    public Ulid ShipId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 25;
}

public class GetPaginatedDrawingsQueryValidator : AbstractValidator<GetPaginatedDrawingsQuery>
{
    public GetPaginatedDrawingsQueryValidator(IShipService service)
    {
        RuleFor(x => x.ShipId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_PAGINATED_DRAWINGS_400_SHIPID")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.ShipId} nie istnieje w bazie!")
            .WithErrorCode("SHIP_404_ID");
    }
}

public class GetPaginatedDrawingsQueryHandler : IRequestHandler<GetPaginatedDrawingsQuery, PaginatedList<DrawingWithNoRelationsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPaginatedDrawingsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DrawingWithNoRelationsDto>> Handle(GetPaginatedDrawingsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Drawings
            .Where(x => x.Ship != null && x.Ship.Id == request.ShipId)
            .OrderBy(x => x.Number)
            .ProjectTo<DrawingWithNoRelationsDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

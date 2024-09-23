using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Application.Common.Models.Iso;

namespace Shiptech.Application.Isos.Queries.GetIsos;

public record GetPaginatedIsosQuery : IRequest<IEnumerable<IsoDto>>
{
    public Ulid DrawingId { get; set; }
}

public class GetPaginatedIsosQueryValidator : AbstractValidator<GetPaginatedIsosQuery>
{
    public GetPaginatedIsosQueryValidator(IDrawingService service)
    {
        RuleFor(x => x.DrawingId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_PAGINATED_ISOS_400_DRAWINGID")
            .WithMessage("Identyfikator rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsById(x))
            .WithMessage(x => $"{x.DrawingId} nie istnieje w bazie!")
            .WithErrorCode("DRAWING_404_ID");
    }
}

public class GetPaginatedIsosQueryHandler : IRequestHandler<GetPaginatedIsosQuery, IEnumerable<IsoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPaginatedIsosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IsoDto>> Handle(GetPaginatedIsosQuery request, CancellationToken cancellationToken)
    {
        return await _context.Isos
            .Where(x => x.Drawing != null && x.Drawing.Id == request.DrawingId)
            .OrderBy(x => x.Number)
            .ProjectTo<IsoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

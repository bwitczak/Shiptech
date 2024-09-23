using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Application.Common.Models.Iso;

namespace Shiptech.Application.Isos.Queries.GetIsos;

public record GetIsosQuery : IRequest<IEnumerable<IsoDto>>
{
    public required string DrawingNumber { get; set; }
}

public class GetIsosQueryValidator : AbstractValidator<GetIsosQuery>
{
    public GetIsosQueryValidator(IDrawingService service)
    {
        RuleFor(x => x.DrawingNumber)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_PAGINATED_ISOS_400_DRAWING_NUMBER")
            .WithMessage("Numer rysunku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsByNumber(x))
            .WithMessage(x => $"{x.DrawingNumber} istnieje w bazie!")
            .WithErrorCode("DRAWING_409_ID");
    }
}

public class GetIsosQueryHandler : IRequestHandler<GetIsosQuery, IEnumerable<IsoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetIsosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IsoDto>> Handle(GetIsosQuery request, CancellationToken cancellationToken)
    {
        return await _context.Isos
            .Where(x => x.Drawing != null && x.Drawing.Number == request.DrawingNumber)
            .OrderBy(x => x.Number)
            .ProjectTo<IsoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

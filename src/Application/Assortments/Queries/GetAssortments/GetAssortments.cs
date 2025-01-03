using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Interfaces.Services;
using Shiptech.Application.Common.Models.Assortment;

namespace Shiptech.Application.Assortments.Queries.GetAssortments;

public record GetAssortmentsQuery : IRequest<IEnumerable<AssortmentDto>>
{
    public required string IsoNumber { get; init; }
}

public class GetAssortmentsQueryValidator : AbstractValidator<GetAssortmentsQuery>
{
    public GetAssortmentsQueryValidator(IIsoService service)
    {
        RuleFor(x => x.IsoNumber)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("GET_PAGINATED_ASSORTMENTS_400_ISO_NUMBER")
            .WithMessage("Identyfikator statku nie może być pusty!")
            .MustAsync(async (x, _) => await service.ExistsByNumber(x))
            .WithMessage(x => $"{x.IsoNumber} nie istnieje w bazie!")
            .WithErrorCode("ISO_404_NUMBER");
    }
}

public class GetAssortmentsQueryHandler : IRequestHandler<GetAssortmentsQuery, IEnumerable<AssortmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAssortmentsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AssortmentDto>> Handle(GetAssortmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Assortments
            .Where(x => x.Iso != null && x.Iso.Number == request.IsoNumber)
            .ProjectTo<AssortmentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}

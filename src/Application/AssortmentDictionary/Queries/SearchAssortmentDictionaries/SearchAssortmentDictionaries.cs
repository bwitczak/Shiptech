using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shiptech.Application.Common.Interfaces.Database;
using Shiptech.Application.Common.Models.AssortmentDictionary;

namespace Shiptech.Application.AssortmentDictionary.Queries.SearchAssortmentDictionaries;

public record SearchAssortmentDictionariesQuery : IRequest<IEnumerable<AssortmentDictionaryDto>>
{
    public required string SearchString { get; set; }
}

public class SearchAssortmentDictionariesQueryValidator : AbstractValidator<SearchAssortmentDictionariesQuery>
{
    public SearchAssortmentDictionariesQueryValidator()
    {
        RuleFor(x => x.SearchString)
            .NotNull()
            .NotEmpty()
            .WithErrorCode("SEARCH_ASSORTMENT_DICTIONARIES_400_SEARCH_STRING")
            .WithMessage("Fraza do wyszukiwania nie może być pusta!");
    }
}

public class
    SearchAssortmentDictionariesQueryHandler : IRequestHandler<SearchAssortmentDictionariesQuery,
    IEnumerable<AssortmentDictionaryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SearchAssortmentDictionariesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AssortmentDictionaryDto>> Handle(SearchAssortmentDictionariesQuery request,
        CancellationToken cancellationToken)
    {
        return await _context
            .AssortmentDictionaries
            .Where(x =>
                x.SearchVector.Matches(EF.Functions.PhraseToTsQuery("english", request.SearchString)))
            .OrderByDescending(x => x.SearchVector.Rank(EF.Functions.PhraseToTsQuery("english", request.SearchString)))
            .ProjectTo<AssortmentDictionaryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}

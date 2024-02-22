using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Infrastructure.Queries.Handlers;

internal sealed class GetPagedDrawingsHandler : IQueryHandler<GetPagedDrawings, IEnumerable<DrawingDto>>
{
    public async Task<IEnumerable<DrawingDto>> HandleAsync(GetPagedDrawings query)
    {
        throw new NotImplementedException();
    }
}
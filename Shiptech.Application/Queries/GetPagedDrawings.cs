using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetPagedDrawings : IQuery<IEnumerable<DrawingWithNoRelationsDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
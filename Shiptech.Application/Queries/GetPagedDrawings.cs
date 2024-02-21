using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetPagedDrawings : IQuery<IEnumerable<DrawingDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
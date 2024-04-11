using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetDrawingWithPagedIsos : IQuery<DrawingDto>
{
    public Guid Id { get; set; }
    public int IsoPageSize { get; set; }
    public int IsoPageNumber { get; set; }
}
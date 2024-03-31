using Shiptech.Application.Dtos;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Application.Queries;

public class GetDrawing : IQuery<DrawingDto>
{
    public Guid Id { get; set; }
}
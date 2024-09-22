using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Common.Models;
using Shiptech.Application.Common.Models.Drawing;
using Shiptech.Application.Common.Models.Iso;
using Shiptech.Application.Common.Models.Ship;
using Shiptech.Application.Drawings.Commands.CreateDrawing;
using Shiptech.Application.Drawings.Commands.DeleteDrawing;
using Shiptech.Application.Drawings.Commands.UpdateDrawing;
using Shiptech.Application.Drawings.Queries.GetDrawings;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Drawings : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllDrawings, "/GetAll")
            .MapPost(CreateDrawing, "/Create")
            .MapPut(UpdateDrawing, "/Update/{id}")
            .MapDelete(DeleteDrawing, "/Delete/{id}");
    }

    private Task<IEnumerable<DrawingWithNoRelationsDto>> GetAllDrawings(ISender sender, [AsParameters] GetPaginatedDrawingsQuery query)
    {
        return sender.Send(query);
    }
    
    private Task CreateDrawing(ISender sender, [FromBody] CreateDrawingCommand command)
    {
        return sender.Send(command);
    }
    
    private Task UpdateDrawing(ISender sender, Ulid id, [FromBody] UpdateDrawingCommand command)
    {
        return sender.Send(command);
    }
    
    private Task DeleteDrawing(ISender sender, Ulid id, [FromBody] DeleteDrawingCommand command)
    {
        return sender.Send(command);
    }
}

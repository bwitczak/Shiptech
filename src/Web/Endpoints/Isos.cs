using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Common.Models;
using Shiptech.Application.Common.Models.Iso;
using Shiptech.Application.Drawings.Commands.CreateDrawing;
using Shiptech.Application.Drawings.Commands.DeleteDrawing;
using Shiptech.Application.Drawings.Commands.UpdateDrawing;
using Shiptech.Application.Isos.Commands.CreateIso;
using Shiptech.Application.Isos.Commands.DeleteIso;
using Shiptech.Application.Isos.Commands.UpdateIso;
using Shiptech.Application.Isos.Queries.GetPaginatedIsos;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Isos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetPaginatedIsos, "/GetPaginated")
            .MapPost(CreateIso, "/Create")
            .MapPut(UpdateIso, "/Update/{id}")
            .MapDelete(DeleteIso, "/Delete/{id}");
    }
    
    private Task<PaginatedList<IsoDto>> GetPaginatedIsos(ISender sender, [AsParameters] GetPaginatedIsosQuery query)
    {
        return sender.Send(query);
    }
    
    private Task CreateIso(ISender sender, [FromBody] CreateIsoCommand command)
    {
        return sender.Send(command);
    }
    
    private Task UpdateIso(ISender sender, Ulid id, [FromBody] UpdateIsoCommand command)
    {
        return sender.Send(command);
    }
    
    private Task DeleteIso(ISender sender, Ulid id, [FromBody] DeleteIsoCommand command)
    {
        return sender.Send(command);
    }
}
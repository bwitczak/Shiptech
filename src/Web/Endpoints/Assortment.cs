using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Assortments.Commands.CreateAssortment;
using Shiptech.Application.Assortments.Commands.DeleteAssortment;
using Shiptech.Application.Assortments.Commands.UpdateAssortment;
using Shiptech.Application.Drawings.Commands.CreateDrawing;
using Shiptech.Application.Drawings.Commands.DeleteDrawing;
using Shiptech.Application.Drawings.Commands.UpdateDrawing;
using Shiptech.Application.Isos.Commands.CreateIso;
using Shiptech.Application.Isos.Commands.DeleteIso;
using Shiptech.Application.Isos.Commands.UpdateIso;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Assortment : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateAssortment, "/Create")
            .MapPut(UpdateAssortment, "/Update/{id}")
            .MapDelete(DeleteAssortment, "/Delete/{id}");
    }
    
    private Task CreateAssortment(ISender sender, [FromBody] CreateAssortmentCommand command)
    {
        return sender.Send(command);
    }
    
    private Task UpdateAssortment(ISender sender, Ulid id, [FromBody] UpdateAssortmentCommand command)
    {
        return sender.Send(command);
    }
    
    private Task DeleteAssortment(ISender sender, Ulid id, [FromBody] DeleteAssortmentCommand command)
    {
        return sender.Send(command);
    }
}

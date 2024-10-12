using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Ships.Commands.CreateShip;
using Shiptech.Application.Ships.Commands.DeleteShip;
using Shiptech.Application.Ships.Commands.UpdateShip;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Ships : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateShip, "/Create")
            .MapPut(UpdateShip, "/Update/{id}")
            .MapDelete(DeleteShip, "/Delete/{id}");
    }

    private Task CreateShip(ISender sender, [FromBody] CreateShipCommand command)
    {
        return sender.Send(command);
    }

    private Task UpdateShip(ISender sender, Ulid id, [FromBody] UpdateShipCommand command)
    {
        return sender.Send(command);
    }

    private Task DeleteShip(ISender sender, Ulid id, [FromBody] DeleteShipCommand command)
    {
        return sender.Send(command);
    }
}

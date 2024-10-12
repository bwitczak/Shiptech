using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Common.Models.Shipowner;
using Shiptech.Application.Shipowners.Commands.CreateShip;
using Shiptech.Application.Shipowners.Commands.DeleteShip;
using Shiptech.Application.Shipowners.Commands.UpdateShip;
using Shiptech.Application.Shipowners.Queries.GetAllShips;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Shipowners : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllShipowners, "/GetAll")
            // .MapGet(GetWithDrawings, "/GetWithDrawings")
            .MapPost(CreateShipowner, "/Create")
            .MapPut(UpdateShipowner, "/Update/{id}")
            .MapDelete(DeleteShipowner, "/Delete/{id}");
    }

    private Task<IEnumerable<ShipownerDto>> GetAllShipowners(ISender sender)
    {
        return sender.Send(new GetAllShipownersQuery());
    }

    private Task CreateShipowner(ISender sender, [FromBody] CreateShipownerCommand command)
    {
        return sender.Send(command);
    }

    private Task UpdateShipowner(ISender sender, Ulid id, [FromBody] UpdateShipownerCommand command)
    {
        return sender.Send(command);
    }

    private Task DeleteShipowner(ISender sender, Ulid id, [FromBody] DeleteShipownerCommand command)
    {
        return sender.Send(command);
    }
}

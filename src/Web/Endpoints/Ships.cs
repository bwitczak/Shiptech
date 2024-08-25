using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Common.Models;
using Shiptech.Application.Common.Models.Ship;
using Shiptech.Application.Ships.Commands.CreateShip;
using Shiptech.Application.Ships.Commands.DeleteShip;
using Shiptech.Application.Ships.Commands.UpdateShip;
using Shiptech.Application.Ships.Queries.GetAllShips;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Ships : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllShips, "/GetAll")
            // .MapGet(GetWithDrawings, "/GetWithDrawings")
            .MapPost(CreateShip, "/Create")
            .MapPut(UpdateShip, "/Update/{id}")
            .MapDelete(DeleteShip, "/Delete/{id}");
    }

    private Task<IEnumerable<ShipWithNoRelationsDto>> GetAllShips(ISender sender)
    {
        return sender.Send(new GetAllShipsQuery());
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

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Assortments.Commands.CreateAssortment;
using Shiptech.Application.Assortments.Commands.DeleteAssortment;
using Shiptech.Application.Assortments.Commands.UpdateAssortment;
using Shiptech.Application.Assortments.Queries.GetAssortments;
using Shiptech.Application.Common.Models.Assortment;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class Assortment : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllAssortments, "/GetAll")
            .MapPost(CreateAssortment, "/Create")
            .MapPut(UpdateAssortment, "/Update/{id}")
            .MapDelete(DeleteAssortment, "/Delete/{id}");
    }

    private Task<IEnumerable<AssortmentDto>> GetAllAssortments(ISender sender,
        [AsParameters] GetAssortmentsQuery query)
    {
        return sender.Send(query);
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

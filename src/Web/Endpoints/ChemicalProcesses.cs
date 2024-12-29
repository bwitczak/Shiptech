using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.ChemicalProcesses.Commands.CreateChemicalProcess;
using Shiptech.Application.ChemicalProcesses.Commands.DeleteChemicalProcess;
using Shiptech.Application.ChemicalProcesses.Commands.UpdateChemicalProcess;
using Shiptech.Application.ChemicalProcesses.Queries.GetAllChemicalProcesses;
using Shiptech.Application.Common.Models.ChemicalProcess;
using Shiptech.Web.Infrastructure;

namespace Shiptech.Web.Endpoints;

public class ChemicalProcesses : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllChemicalProcesses, "/GetAll")
            .MapPost(CreateChemicalProcess, "/Create")
            .MapPut(UpdateChemicalProcess, "/Update/{id}")
            .MapDelete(DeleteChemicalProcess, "/Delete/{id}");
    }

    private Task<IEnumerable<ChemicalProcessDto>> GetAllChemicalProcesses(ISender sender)
    {
        return sender.Send(new GetAllChemicalProcessesQuery());
    }

    private Task CreateChemicalProcess(ISender sender, [FromBody] CreateChemicalProcessCommand command)
    {
        return sender.Send(command);
    }

    private Task UpdateChemicalProcess(ISender sender, Ulid id, [FromBody] UpdateChemicalProcessCommand command)
    {
        return sender.Send(command);
    }

    private Task DeleteChemicalProcess(ISender sender, Ulid id, [FromBody] DeleteChemicalProcessCommand command)
    {
        return sender.Send(command);
    }
}

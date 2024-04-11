using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.ChemicalProcess;
using Shiptech.Application.Validators.Ship;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChemicalProcessController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IChemicalProcessReadService _readService;

    public ChemicalProcessController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IChemicalProcessReadService readService)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _readService = readService;
    }
    
    [HttpGet]
    public async Task<IResult> Get([FromQuery] GetChemicalProcess query)
    {
        var validator = new GetChemicalProcessValidator(_readService);
        var result = await validator.ValidateAsync(query);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        var chemicalProcess = await _queryDispatcher.QueryAsync(query);

        return Results.Ok(chemicalProcess);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ChemicalProcessDto>>> GetAll([FromQuery] GetAllChemicalProcesses query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateChemicalProcess command)
    {
        var validator = new CreateChemicalProcessValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpPut]
    public async Task<IResult> Put([FromBody] UpdateChemicalProcess command)
    {
        var validator = new UpdateChemicalProcessValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IResult> Delete([FromRoute] DeleteChemicalProcess command)
    {
        var validator = new DeleteChemicalProcessValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
}
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Ship;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IShipReadService _readService;

    public ShipController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IShipReadService readService)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _readService = readService;
    }

    [HttpGet]
    public async Task<IResult> GetWithDrawings([FromQuery] GetShipWithPagedDrawings query)
    {
        var validator = new GetShipWithPagedDrawingsValidator(_readService);
        var result = await validator.ValidateAsync(query);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        var ship = await _queryDispatcher.QueryAsync(query);

        return Results.Ok(ship);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ShipWithNoRelationsDto>>> GetAll(GetAllShips query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateShip command)
    {
        var validator = new CreateShipValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpPut]
    public async Task<IResult> Put([FromBody] UpdateShip command)
    {
        var validator = new UpdateShipValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IResult> Delete([FromRoute] DeleteShip command)
    {
        var validator = new DeleteShipValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
}
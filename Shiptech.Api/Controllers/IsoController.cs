using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Iso;
using Shiptech.Application.Validators.Ship;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IsoController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IIsoReadService _readService;

    public IsoController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IIsoReadService readService)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _readService = readService;
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<IsoDto>> Get([FromRoute] GetIso query)
    // {
    //     var result = await _queryDispatcher.QueryAsync(query);
    //
    //     if (result is null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return Ok(result);
    // }
    //
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<IsoDto>>> GetAll([FromQuery] GetAllIsos query)
    // {
    //     var result = await _queryDispatcher.QueryAsync(query);
    //
    //     return Ok(result);
    // }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateIso command)
    {
        var validator = new CreateIsoValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpPut]
    public async Task<IResult> Put([FromBody] UpdateIso command)
    {
        var validator = new UpdateIsoValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IResult> Delete([FromRoute] DeleteIso command)
    {
        var validator = new DeleteIsoValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
}
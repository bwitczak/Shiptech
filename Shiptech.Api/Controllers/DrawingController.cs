using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Drawing;
using Shiptech.Application.Validators.Ship;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrawingController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IDrawingReadService _readService;

    public DrawingController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IDrawingReadService readService)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _readService = readService;
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get([FromRoute] GetDrawing query)
    {
        var validator = new GetDrawingValidator(_readService);
        var result = await validator.ValidateAsync(query);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        var drawing = await _queryDispatcher.QueryAsync(query);

        return Results.Ok(drawing);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DrawingDto>>> GetPaged([FromQuery] GetPagedDrawings query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
    
        return Ok(result);
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateDrawing command)
    {
        var validator = new CreateDrawingValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpPut]
    public async Task<IResult> Put([FromBody] UpdateDrawing command)
    {
        var validator = new UpdateDrawingValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IResult> Delete([FromRoute] DeleteDrawing command)
    {
        var validator = new DeleteDrawingValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
}
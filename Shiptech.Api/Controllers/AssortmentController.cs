using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Assortment;
using Shiptech.Application.Validators.Ship;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssortmentController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IAssortmentReadService _readService;

    public AssortmentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IAssortmentReadService readService)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _readService = readService;
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateAssortment command)
    {
        var validator = new CreateAssortmentValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpPut]
    public async Task<IResult> Put([FromBody] UpdateAssortment command)
    {
        var validator = new UpdateAssortmentValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IResult> Delete([FromRoute] DeleteAssortment command)
    {
        var validator = new DeleteAssortmentValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
}
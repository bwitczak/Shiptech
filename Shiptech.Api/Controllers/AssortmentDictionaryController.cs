using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Application.Services;
using Shiptech.Application.Validators.Assortment;
using Shiptech.Application.Validators.AssortmentDictionary;
using Shiptech.Application.Validators.Ship;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssortmentDictionaryController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IAssortmentDictionaryReadService _readService;

    public AssortmentDictionaryController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IAssortmentDictionaryReadService readService)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _readService = readService;
    }
    
    [HttpGet("{id}")]
    public async Task<IResult> Get([FromRoute] GetAssortmentDictionary query)
    {
        var validator = new GetAssortmentDictionaryValidator(_readService);
        var result = await validator.ValidateAsync(query);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        var assortmentDictionary = await _queryDispatcher.QueryAsync(query);

        return Results.Ok(assortmentDictionary);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShipDto>>> GetPaged([FromQuery] GetPagedAssortmentDictionary query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IResult> Post([FromBody] CreateAssortmentDictionary command)
    {
        var validator = new CreateAssortmentDictionaryValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpPut]
    public async Task<IResult> Put([FromBody] UpdateAssortmentDictionary command)
    {
        var validator = new UpdateAssortmentDictionaryValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IResult> Delete([FromRoute] DeleteAssortmentDictionary command)
    {
        var validator = new DeleteAssortmentDictionaryValidator(_readService);
        var result = await validator.ValidateAsync(command);

        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }
        
        await _commandDispatcher.DispatchAsync(command);

        return Results.Ok();
    }
}
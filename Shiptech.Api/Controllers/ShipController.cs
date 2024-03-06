using Microsoft.AspNetCore.Mvc;
using Shiptech.Application.Commands;
using Shiptech.Application.Dtos;
using Shiptech.Application.Queries;
using Shiptech.Shared.Abstractions.Commands;
using Shiptech.Shared.Abstractions.Queries;

namespace Shiptech.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ShipController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShipDto>> Get([FromRoute] GetShip query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShipDto>>> GetAll([FromQuery] GetAllShips query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateShip command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return CreatedAtAction(nameof(Post), new { id = command.Id }, null);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateShip command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteShip command)
    {
        await _commandDispatcher.DispatchAsync(command);

        return Ok();
    }
}
using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

public class CreateShipHandler : ICommandHandler<CreateShip>
{
    private readonly IShipRepository _repository;
    private readonly IShipFactory _factory;
    private readonly IShipReadService _readService;
    
    public async Task HandleAsync(CreateShip command)
    {
        var (id, orderer) = command;
        
        if (await _readService.ExistsByOrderer(orderer))
        {
            throw new ShipOrdererAlreadyExistsException(orderer);
        }

        var ship = _factory.Create(id, orderer);

        await _repository.CreateAsync(ship);
    }
}
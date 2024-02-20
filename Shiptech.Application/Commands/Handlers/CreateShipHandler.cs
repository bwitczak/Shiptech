using Shiptech.Application.Exceptions;
using Shiptech.Application.Services;
using Shiptech.Domain.Factories;
using Shiptech.Domain.Repositories;
using Shiptech.Shared.Abstractions.Commands;

namespace Shiptech.Application.Commands.Handlers;

internal sealed class CreateShipHandler(IShipRepository repository, IShipFactory factory, IShipReadService readService)
    : ICommandHandler<CreateShip>
{
    public async Task HandleAsync(CreateShip command)
    {
        var (id, orderer) = command;

        if (await readService.ExistsByOrderer(orderer))
        {
            throw new ShipOrdererAlreadyExistsException(orderer);
        }

        var ship = factory.Create(id, orderer);
        await repository.CreateAsync(ship);
    }
}